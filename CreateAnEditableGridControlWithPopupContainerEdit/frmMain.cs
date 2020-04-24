using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CreateAnEditableGridControlWithPopupContainerEdit
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = FillDataTable();
            controlNavigator1.NavigatableControl = gridControl1;

            popupContainerControl1.Controls.Add(gridControl1);
            popupContainerControl1.Controls.Add(controlNavigator1);

            popupContainerEdit1.Properties.PopupControl = popupContainerControl1;
            popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            popupContainerEdit1.QueryDisplayText += new DevExpress.XtraEditors.Controls.QueryDisplayTextEventHandler(popupContainerEdit1_QueryDisplayText);
            popupContainerEdit1.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(popupContainerEdit1_QueryResultValue);

            this.gridView1.Columns[0].MaxWidth = 30; //Id
            this.gridView1.Columns[1].MaxWidth = 120; //AdSoyad
            this.gridView1.Columns[2].MaxWidth = 30; //AdSoyad
        }

        private void popupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            e.Value = gridView1.GetFocusedRowCellValue("AdSoyad");
        }

        private void popupContainerEdit1_QueryDisplayText(object sender, DevExpress.XtraEditors.Controls.QueryDisplayTextEventArgs e)
        {
            e.DisplayText = e.EditValue != null ? e.EditValue.ToString() : "";
        }

        private DataTable FillDataTable()
        {
            DataTable _dataTable = new DataTable();
            DataColumn col;
            DataRow row;

            col = new DataColumn();
            col.ColumnName = "Id";
            col.DataType = System.Type.GetType("System.Int32");
            _dataTable.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "AdSoyad";
            col.DataType = System.Type.GetType("System.String");
            _dataTable.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "Aktif";
            col.DataType = System.Type.GetType("System.Boolean");
            _dataTable.Columns.Add(col);

            row = _dataTable.NewRow();
            row["Id"] = "1"; row["AdSoyad"] = "Ali Doğan"; row["Aktif"] = true;
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            row["Id"] = "2"; row["AdSoyad"] = "Mehmet Yılmaz"; row["Aktif"] = false;
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            row["Id"] = "3"; row["AdSoyad"] = "Recep Mert"; row["Aktif"] = true;
            _dataTable.Rows.Add(row);

            return _dataTable;
        }
    }
}