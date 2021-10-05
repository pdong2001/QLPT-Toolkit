using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolkit;
using Microsoft.Win32;
using System.Windows;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;
using Collection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace QLPT_Toolkit
{
    public partial class FindAddressID : Form
    {
        public FindAddressID()
        {
            InitializeComponent();
        }
        #region Thuộc tính
        BindingSource source = new BindingSource();
        Tree<string, string> addressData = new Tree<string, string>();
        DataTable data = new DataTable();
        Dictionary<string, string[]> ToReplace = new Dictionary<string, string[]>();
        List<int[]> Errors = new List<int[]>();
        int currentErrors = -1;
        int colYear = 0;
        List<int> AddressColumns = new List<int>();
        int colName = 0;
        List<Column> lData = new List<Column>();
        bool BirthFlag = true, NameFlag = true, AddressIDFlag = true;
        private int currentProcess = 0;
        private int waitingProcesses = 0;
        private bool Saved = true;
        #endregion

        #region Phương thức
        private async Task SetAddressID(Column data, Column RS, Column AD, int index)
        {
            Task t = new Task(() =>
            {
                AddressIDFlag = false;
                waitingProcesses += data.Rows.Count;
                addressData.RefreshRank();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    lock (data)
                    {
                        string Result;
                        string FoundAddress = FindID(data.Rows[i], out Result);
                        if (FoundAddress.Length == 0)
                        {
                            Errors.Add(new int[] { i, index, 1 });
                        }
                        RS.Rows.Add(Result);
                        AD.Rows.Add(FoundAddress);
                    }
                    currentProcess++;
                }
            });
            t.Start();
            await t;
            AddressIDFlag = true;
            WhenTaskCompleted();
        }


        private async Task StandardizeName(Column data, int index)
        {
            Task t = new Task(() =>
            {
                NameFlag = false;
                waitingProcesses += data.Rows.Count;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    lock (data)
                    {
                        string temp = StringStandardize.NameStandardize(data.Rows[i].ToString().ToLower());
                        data.Rows[i] = temp;
                        if (Regex.IsMatch(temp, @"\d|[,.\|\\-\\/+`~*@#$%^&()=]"))
                        {
                            Errors.Add(new int[] { i, index, 0 });
                        }
                    }
                    currentProcess++;
                }
            });
            t.Start();
            await t;
            NameFlag = true;
            WhenTaskCompleted();
        }

        private async Task YearOfBirth(Column data, int index)
        {
            Task t = new Task(() =>
            {
                BirthFlag = false;
                waitingProcesses += data.Rows.Count;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    lock (data)
                    {
                        string temp;
                        temp = data.Rows[i].ToString();
                        for (int j = 0; j < temp.Length; j++)
                        {
                            if (temp[j] < 48 || temp[j] > 57)
                            {
                                temp = temp.Replace(temp[j], ' ');
                            }
                        }
                        data.Rows[i] = StringStandardize.RemoveSpace(temp);
                        if (string.IsNullOrEmpty(temp) || temp.Contains(" "))
                        {
                            Errors.Add(new int[] { i, index, 2 });
                        }
                    }
                    currentProcess++;
                }
            });
            t.Start();
            await t;
            BirthFlag = true;
            WhenTaskCompleted();
        }


        public void WhenTaskCompleted()
        {
            if (AddressIDFlag && NameFlag && BirthFlag)
            {
                timerErrors.Enabled = true;
                this.data = Column.ToTable(lData);
                source.DataSource = null;
                source.DataSource = this.data;
                MessageBox.Show("Hoàn thành.");
                progressBarX1.Maximum = 0;
                currentProcess = 0;
                waitingProcesses = 0;
                if (cbxDetectColumns.SelectedIndex != -1)
                {
                    int index = ((CBItem)cbxDetectColumns.SelectedItem).Value;
                    for (int i = 0; i < Errors.Count; i++)
                    {
                        if (Errors[i][1] > index)
                        {
                            Errors[i][1] += 2;
                        }
                    }
                }
                comboBoxEx1.SelectedIndex = -1;
                cbxColumsNumberOnly.SelectedIndex = -1;
                cbxDetectColumns.SelectedIndex = -1;
            }
        }

        private string FindID(object name, out string Result)
        {
            char[] splitBy = { '-', ',', '/', '\\' };
            string address = StringStandardize.AddressStandardize(name.ToString().Normalize().ToLower(), ToReplace, splitBy);
            address = Regex.Replace(address, "p\\d|q\\d", (match) => { return match.ToString().Substring(1); });
            address = StringStandardize.RemoveSpace(address);
            if (address.Length == 0)
            {
                Result = "Not found";
                return "";
            }
            string[] toSearch = address.Split(splitBy);
            string Address = "";
            Node<string, string> node = null;
            for (int j = toSearch.Length - 1; j >= 0; j--)
            {
                toSearch[j] = toSearch[j].Trim().ToLower();
                if (node == null)
                {
                    node = addressData.FindNode((Key) =>
                    {
                        Key = Key.ToLower();
                        return Key.Contains(toSearch[j]) || Key == toSearch[j];
                    });
                }
                else if (node.Value.Length < 6)
                {
                    Node<string, string> temp = node.FindNode((Key) =>
                    {
                        Key = Key.ToLower();
                        return Key.Contains(toSearch[j]) || Key == toSearch[j];
                    });
                    node = temp == null ? node : temp;
                }
                else if (node.Value.Length == 6)
                {
                    break;
                }
            }

            if (node != null)
            {
                Result = node.Value;
            }
            else
            {
                Result = "Not found";
                Address = "";
            }
            while (node != null)
            {
                Address += ", " + node.Key;
                node = node.Root;
            }

            return Address;
        }

        private async Task ImportData(string FileName)
        {
            List<object> items = new List<object>();
            Task t = new Task(() =>
            {
                //try
                {
                    // mở file excel
                    waitingProcesses = 100;
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    var package = new ExcelPackage(new FileInfo(FileName));
                    currentProcess = 15;
                    // lấy ra sheet đầu tiên để thao tác
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                    currentProcess = 20;
                    // gắn dòng đầu tiên cho tên cột của bảng dữ liệu.
                    data = new DataTable();

                    AddressColumns.Clear();
                    colName = -1;
                    colYear = -1;
                    currentProcess = 25;

                    int k = 0;
                    for (int i = workSheet.Dimension.Start.Column; i <= workSheet.Dimension.End.Column; i++)
                    {
                        data.Columns.Add(new DataColumn((string)workSheet.Cells[1, i].Value));
                        items.Add(new CBItem((string)workSheet.Cells[1, i].Value, k++));
                    }
                    currentProcess = 50;
                    // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                    for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var temp = new object[workSheet.Dimension.Columns];
                        k = 0;
                        for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                        {
                            object Value = workSheet.Cells[i, j].Value;
                            temp[k++] = Value == null ? "" : Value.ToString().Normalize();
                        }
                        data.Rows.Add(temp);
                    }
                    currentProcess = 90;
                    data.AcceptChanges();
                }
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            });
            t.Start();
            await t;
            source.DataSource = data;
            currentProcess = 100;
            object[] cbItems = items.ToArray();
            comboBoxEx1.Items.AddRange(cbItems);
            cbxColumsNumberOnly.Items.AddRange(cbItems);
            cbxDetectColumns.Items.AddRange(cbItems);
            comboBoxEx1.SelectedIndex = -1;
            cbxColumsNumberOnly.SelectedIndex = -1;
            cbxDetectColumns.SelectedIndex = -1;
            Thread.Sleep(100);
            currentProcess = 0;
            waitingProcesses = 0;
        }
        #endregion

        #region Sự kiện
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                colorDialog1.Color = Properties.Settings.Default.ExportCellsColor;
                button1.BackColor = colorDialog1.Color;

                currentProcess = 0;
                waitingProcesses = 0;
                // mở file excel
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                var package = new ExcelPackage(new FileInfo("Data_Address.xlsx"));

                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 4; i <= workSheet.Dimension.End.Row; i++)
                {
                    if (workSheet.Cells[i, 3].Value != null)
                    {
                        string[] Tinh = ((string)workSheet.Cells[i, 3].Value).Normalize().Split(':');
                        string[] Huyen = ((string)workSheet.Cells[i, 2].Value).Normalize().Split(':');
                        string[] Xa = ((string)workSheet.Cells[i, 1].Value).Normalize().Split(':');
                        if (Tinh.Length == 2)
                        {
                            Tinh[1] = Tinh[1].Trim();
                            Huyen[1] = Huyen[1].Trim();
                            Xa[1] = Xa[1].Trim();

                            if (addressData.CurrentNode != null && addressData.CurrentNode.Key == Tinh[1])
                            {
                                if (addressData.CurrentNode.CurrentNode != null && addressData.CurrentNode.CurrentNode.Key == Huyen[1])
                                {
                                    addressData.CurrentNode.CurrentNode.AddChild(Xa[1], Xa[0]);
                                }
                                else
                                {
                                    addressData.CurrentNode.AddChild(new Node<string, string>(Huyen[1], Huyen[0]));
                                    addressData.CurrentNode.CurrentNode.AddChild(Xa[1], Xa[0]);
                                }
                            }
                            else
                            {
                                addressData.AddNode(null, Tinh[1], Tinh[0]);
                                addressData.CurrentNode.AddChild(new Node<string, string>(Huyen[1], Huyen[0]));
                                addressData.CurrentNode.CurrentNode.AddChild(Xa[1], Xa[0]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ToReplace.Add(" Hà Nội ", new string[] { "ha noi", "hn" });
            ToReplace.Add(" HCM ", new string[] { "ho chi minh", "hồ chí minh", "hcm" });
            ToReplace.Add(" ", new string[] { "\\." });
            ToReplace.Add("", new string[] { "0", "phường", "phướng", "phuong", "thị", "thi\\s", "tx", "tt", "trấn", "tran", "\\Wp\\s", "tp", "quận", "huyen", "huyện", "quan", "ctn", "q\\W", "thành phố", "thanh pho", "^t\\W", "tinh", "tỉnh", "xa", "xã" });
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            Errors.Clear();
            OpenFileDialog oFDExcelInput = new OpenFileDialog();
            oFDExcelInput.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.xlsb";
            if (oFDExcelInput.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = oFDExcelInput.FileName;
                _ = ImportData(oFDExcelInput.FileName);
                dgvAddress.DataSource = source;
                Saved = false;
            }
        }

        private void btnFindAddressIDCheck_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length == 0)
            {
                MessageBox.Show("Thêm vào file Excel cần xử lý.", "Thông báo");
                return;
            }
            lData = Column.SplitDataTable(data);
            try
            {
                Saved = false;
                Task t1, t2, t3;
                if (cbxColumsNumberOnly.SelectedItem != null && BirthFlag)
                {
                    Errors.Where((er) => { return er[2] == 2; }).ToList().ForEach((er) => { Errors.Remove(er); });
                    colYear = (cbxColumsNumberOnly.SelectedItem as CBItem).Value;
                    t1 = YearOfBirth(lData[colYear], colYear);
                }
                if (cbxDetectColumns.SelectedItem != null && AddressIDFlag)
                {
                    CBItem Item = ((CBItem)cbxDetectColumns.SelectedItem);
                    Errors.Where((er) => { return er[2] == 0 && er[1] == Item.Value; }).ToList().ForEach((er) => { Errors.Remove(er); });
                    Column RS = new Column("Mã " + Item.Key), AD = new Column(Item.Key + " tìm được");
                    bool Check = true;
                    for (int i = 0; i < AddressColumns.Count; i++)
                    {
                        if (AddressColumns[i] == Item.Value)
                        {
                            Check = false;
                            break;
                        }
                    }
                    if (Check)
                    {
                        lData.InsertRange(Item.Value + 1, new Column[] { RS, AD });
                        foreach (CBItem item in cbxDetectColumns.Items)
                        {
                            if (item.Value > Item.Value)
                            {
                                item.Value += 2;
                            }
                        }
                        for (int i = 0; i < AddressColumns.Count; i++)
                        {
                            if (AddressColumns[i] > Item.Value)
                            {
                                AddressColumns[i] += 2;
                            }
                        }
                        for (int i = 0; i < Errors.Count; i++)
                        {
                            if (Errors[i][1] > Item.Value)
                            {
                                Errors[i][1] += 2;
                            }
                        }
                        AddressColumns.Add(Item.Value);
                    }
                    else
                    {
                        RS = lData[Item.Value + 1];
                        AD = lData[Item.Value + 2];
                        RS.Rows.Clear();
                        AD.Rows.Clear();
                    }

                    t2 = SetAddressID(lData[Item.Value], RS, AD, Item.Value);
                }
                if (comboBoxEx1.SelectedItem != null && NameFlag)
                {
                    Errors.Where((er) => { return er[2] == 0; }).ToList().ForEach((er) => { Errors.Remove(er); });
                    colName = (comboBoxEx1.SelectedItem as CBItem).Value;
                    t3 = StandardizeName(lData[colName], colName);
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);
            }
        }

        private void timerErrors_Tick(object sender, EventArgs e)
        {
            if (Errors.Count == 0)
            {
                pnlErrorsNotice.Visible = false;
                currentErrors = -1;
            }
            else
            {
                pnlErrorsNotice.Visible = true;
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            dgvAddress.Focus();
            currentErrors = currentErrors + 1 >= Errors.Count ? 0 : currentErrors + 1;
            dgvAddress.CurrentCell = dgvAddress.Rows[Errors[currentErrors][0]].Cells[Errors[currentErrors][1]];
        }

        private void dgvAddress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow row = ((DataRowView)dgvAddress.Rows[e.RowIndex].DataBoundItem).Row;
            for (int i = 0; i < AddressColumns.Count; i++)
            {
                if (AddressColumns[i] == e.ColumnIndex)
                {
                    string Result;
                    string FoundAddress = FindID(dgvAddress[e.ColumnIndex, e.RowIndex].Value, out Result);
                    if (FoundAddress.Length > 0)
                    {
                        row[AddressColumns[i] + 1] = Result;
                        row[AddressColumns[i] + 2] = FoundAddress;
                        for (int j = 0; j < Errors.Count; j++)
                        {
                            if (Errors[j][0] == e.RowIndex && Errors[j][2] == 1)
                            {
                                Errors.RemoveAt(j);
                            }
                        }
                    }
                    return;
                }
            }
            if (e.ColumnIndex == colName)
            {
                string temp = StringStandardize.NameStandardize(data.Rows[e.RowIndex][e.ColumnIndex].ToString().ToLower());
                row[e.ColumnIndex] = temp;
                for (int j = 0; j < Errors.Count; j++)
                {
                    if (Errors[j][0] == e.RowIndex && Errors[j][2] == 0)
                    {
                        Errors.RemoveAt(j);
                    }
                }
            }
            if (e.ColumnIndex == colYear)
            {
                string temp = Regex.Replace(data.Rows[e.RowIndex][e.ColumnIndex].ToString(), @"\W", (match) =>
                {
                    return " ";
                });
                row[e.ColumnIndex] = StringStandardize.RemoveSpace(temp);
                if (!Regex.IsMatch(temp, "\\D"))
                {
                    for (int j = 0; j < Errors.Count; j++)
                    {
                        if (Errors[j][0] == e.RowIndex && Errors[j][2] == 2)
                        {
                            Errors.RemoveAt(j);
                        }
                    }
                }

            }
            Saved = false;
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {
            progressBarX1.Visible = waitingProcesses > 0;
            progressBarX1.Maximum = waitingProcesses;
            progressBarX1.Value = currentProcess <= progressBarX1.Maximum ? currentProcess : 0;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                Properties.Settings.Default.ExportCellsColor = colorDialog1.Color;
            }
        }

        private void contextMenuBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void FindAddressID_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void FindAddressID_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                switch (MessageBox.Show("Bạn có muốn lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case (DialogResult.Yes):
                        {
                            btnExportToExcel.PerformClick();
                            if (!Saved) { e.Cancel = true; }
                            break;
                        }
                    case (DialogResult.Cancel):
                        {
                            e.Cancel = true;
                            break;
                        }
                }
            }
            else
            {
                if (MessageBox.Show("Thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (!(NameFlag && AddressIDFlag && BirthFlag))
            {
                MessageBox.Show("Đang xử lý, vui lòng chờ.", "Thông báo");
                return;
            }
            if (Errors.Count > 0)
            {
                if (MessageBox.Show("Chưa xử lý hết lỗi, bạn có chắc chắn muốn xuất dữ liệu?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }
            }
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm;*.xlsb";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = "CTN Phật Tử Phật Quang";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Dữ liệu nhân sự";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("Data");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];

                    // đặt tên cho sheet
                    ws.Name = "Data";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 11;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Times New Roman";

                    // Tạo danh sách các column header
                    List<string> arrColumnHeader = new List<string>();
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        arrColumnHeader.Add(data.Columns[i].ColumnName);
                    }

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    int colIndex = 1;
                    int rowIndex = 1;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.LightDown;
                        fill.BackgroundColor.SetColor(Color.LightBlue);


                        //gán giá trị
                        cell.Value = item;

                        colIndex++;
                    }

                    // lấy ra danh sách UserInfo từ ItemSource của DataGrid

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (DataRow item in data.Rows)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;
                        //gán giá trị cho từng cell
                        for (int j = 0; j < countColHeader; j++)
                        {
                            ws.Cells[rowIndex, colIndex++].Value = item[j];
                        }
                    }
                    if (ckbColorErrorsCell.Checked)
                        for (int k = 0; k < Errors.Count; k++)
                        {
                            var cell = ws.Cells[Errors[k][0] + 2, Errors[k][1] + 1];
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(colorDialog1.Color);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                Saved = true;
                if (MessageBox.Show("Xuất excel thành công."+Environment.NewLine + "Bạn có muốn mở tệp?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(filePath);
                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Có lỗi khi lưu file!" + Environment.NewLine + EE.Message);
            }
        }
        #endregion

        #region Đối tượng
        class CBItem
        {
            public string Key = "";
            public int Value = 0;
            public CBItem() { }
            public CBItem(string Key, int Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
            public override string ToString()
            {
                return Key;
            }
        }
        #endregion
    }
}
