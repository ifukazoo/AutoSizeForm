using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoSizeForm
{
    public partial class AutoSizeForm : Form
    {
        public AutoSizeForm()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        static readonly int LABEL_MAX = 3;

        public static void Show(string[] msg)
        {
            using (var form = new AutoSizeForm())
            {
                int[] widths = new int[LABEL_MAX];
                int labelIdx = 0;
                // メッセージをラベルにセットし，AutoSizeされたラベルの幅を保存する
                for (var msgIdx = 0; msgIdx < msg.Length; msgIdx++)
                {
                    Label label = (Label)form.Controls[$"label{labelIdx}"];
                    label.Text = msg[msgIdx];
                    widths[labelIdx] = label.Width;

                    labelIdx++;
                }

                // 最長幅ラベルの幅値を取得
                var maxWidth = widths.Max();

                // タイトル幅は最長幅ラベルに合わせる
                form.Title.Width = maxWidth;

                // 各ラベルをセンタリングするため，最長幅に対する各ラベルの開始X座標を計算して設定する
                for (var i = 0; i < labelIdx; i++)
                {
                    Label label = (Label)form.Controls[$"label{i}"];
                    var x = (maxWidth / 2) - (label.Width / 2);
                    label.Location = new Point(x, label.Location.Y);
                }

                // 使用しないラベルをFormから削除する
                for (; labelIdx < LABEL_MAX; labelIdx++)
                {
                    Label label = (Label)form.Controls[$"label{labelIdx}"];
                    form.Controls.Remove(label);
                }
                form.ShowDialog();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
