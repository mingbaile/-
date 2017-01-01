namespace MyGame
{
    partial class ucItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucItem));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "0001.png");
            this.imageList1.Images.SetKeyName(1, "0002.png");
            this.imageList1.Images.SetKeyName(2, "003.png");
            this.imageList1.Images.SetKeyName(3, "004.png");
            this.imageList1.Images.SetKeyName(4, "0006.png");
            this.imageList1.Images.SetKeyName(5, "0005.png");
            this.imageList1.Images.SetKeyName(6, "010.png");
            this.imageList1.Images.SetKeyName(7, "008.png");
            this.imageList1.Images.SetKeyName(8, "0009.png");
            this.imageList1.Images.SetKeyName(9, "0007.png");
            // 
            // ucItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyGame.Properties.Resources.img0;
            this.Name = "ucItem";
            this.Size = new System.Drawing.Size(35, 35);
            this.Load += new System.EventHandler(this.ucItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
    }
}
