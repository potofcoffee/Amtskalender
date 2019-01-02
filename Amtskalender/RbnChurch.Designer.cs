namespace Amtskalender
{
    partial class RbnChurch : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RbnChurch()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">"true", wenn verwaltete Ressourcen gelöscht werden sollen, andernfalls "false".</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RbnChurch));
            this.TabChurch = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btnCategorize = this.Factory.CreateRibbonButton();
            this.btnRules = this.Factory.CreateRibbonButton();
            this.TabChurch.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabChurch
            // 
            this.TabChurch.Groups.Add(this.group1);
            this.TabChurch.Label = "Kirchentools";
            this.TabChurch.Name = "TabChurch";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.btnCategorize);
            this.group1.Items.Add(this.btnRules);
            this.group1.Label = "Amtskalender";
            this.group1.Name = "group1";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Erstellen";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnCategorize
            // 
            this.btnCategorize.Label = "Kategorisieren...";
            this.btnCategorize.Name = "btnCategorize";
            this.btnCategorize.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // btnRules
            // 
            this.btnRules.Label = "Regeln...";
            this.btnRules.Name = "btnRules";
            // 
            // RbnChurch
            // 
            this.Name = "RbnChurch";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.TabChurch);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.TabChurch.ResumeLayout(false);
            this.TabChurch.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        public Microsoft.Office.Tools.Ribbon.RibbonTab TabChurch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCategorize;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRules;
    }

    partial class ThisRibbonCollection
    {
        internal RbnChurch Ribbon1
        {
            get { return this.GetRibbon<RbnChurch>(); }
        }
    }
}
