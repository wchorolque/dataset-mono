using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DAL;

namespace UI
{
    public class FrmEmployee : Form
    {
        #region Atributos
        private IEmployee m_empleado ;
        #endregion

        #region Controles
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButton;

        #endregion

        #region Constructores
        public FrmEmployee (IEmployee empleado)
        {
            this.m_empleado = empleado;
            InitializeComponent ();

            this.Load += new EventHandler (this.FormOnLoadAction);
        }

        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }
        #endregion

        #region Metodos
        private void InitializeComponent ()
        {
            this.Size = new Size (500, 500);
            this.components = new System.ComponentModel.Container ();

            this.bindingSource = new BindingSource (this.components);
            this.bindingNavigator = new BindingNavigator (this.components);
            this.dataGridView = new DataGridView ();
            this.toolStripButton = new ToolStripButton ();
          
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit ();
            this.SuspendLayout ();

            dataGridView.AllowUserToAddRows = false;

            bindingNavigator.Dock = DockStyle.Top;
            bindingNavigator.Size = new Size (400, 25);
            bindingNavigator.Location = new Point (0, 0);
            bindingNavigator.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            bindingNavigator.Items.AddRange (new ToolStripItem[]{
                this.toolStripButton
            });

            this.toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton.Size = new Size (25, 100);
            this.toolStripButton.Text = "Texto de Prueba";


            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Size = new Size (300, 300);
            dataGridView.Location = new Point (0, 50);
            dataGridView.BackgroundColor = Color.Yellow;

           
            this.Controls.Add (bindingNavigator);
            this.Controls.Add (dataGridView);

            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit ();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit ();

            this.ResumeLayout (false);
            this.PerformLayout ();
        }

        public void FormOnLoadAction (object sender, EventArgs e)
        {
            DataTable dataTable = m_empleado.GetEmployees ();
            bindingSource.DataSource = dataTable;
            dataGridView.DataSource = bindingSource;
        }

        #endregion
    }
}

