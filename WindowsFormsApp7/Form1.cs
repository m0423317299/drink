using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        //類別變數, class variables
        int 杯數1 = 0, 杯數2 = 0, 杯數3 = 0, 杯數4 = 0, 杯數5 = 0;
        double 售價1 = 0.0, 售價2 = 0.0, 售價3 = 0.0, 售價4 = 0.0, 售價5 = 0.0;
        double 品項1總價 = 0.0, 品項2總價 = 0.0, 品項3總價 = 0.0, 品項4總價 = 0.0, 品項5總價 = 0.0;
        double 同品項1總價 = 0.0, 同品項2總價 = 0.0, 同品項3總價 = 0.0, 同品項4總價 = 0.0, 同品項5總價 = 0.0;
        double 買一送一1總價 = 0.0, 買一送一2總價 = 0.0, 買一送一3總價 = 0.0, 買一送一4總價 = 0.0, 買一送一5總價 = 0.0;
        double 折數 = 0.0;
        double 總價 = 0.0;
        double 折扣總價 = 0.0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl品名1.Text = "麥香紅茶";
            lbl品名2.Text = "茉莉綠茶";
            lbl品名3.Text = "珍珠奶茶";
            lbl品名4.Text = "玫瑰花茶";
            lbl品名5.Text = "現打西瓜汁";

            售價1 = 35.0;
            售價2 = 40.0;
            售價3 = 45.0;
            售價4 = 50.0;
            售價5 = 55.0;

            lbl售價1.Text = 售價1.ToString();
            lbl售價2.Text = 售價2.ToString();
            lbl售價3.Text = 售價3.ToString();
            lbl售價4.Text = 售價4.ToString();
            lbl售價5.Text = 售價5.ToString();

            折數 = 10.0;
        }

        private void btn杯數1減_Click(object sender, EventArgs e)
        {
            杯數1 -= 1;
            if (杯數1 < 0)
            {
                杯數1 = 0;
                btn杯數1減.Enabled = false;
            }
            tb杯數1.Text = 杯數1.ToString();
        }

        private void btn杯數1加_Click(object sender, EventArgs e)
        {
            杯數1 += 1;
            btn杯數1減.Enabled = true;
            tb杯數1.Text = 杯數1.ToString();
        }

        private void tb杯數1_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數1.Text !="")
            {
                bool ifNum = System.Int32.TryParse(tb杯數1.Text, out 杯數1);
                if ((ifNum == true) && (杯數1 >= 0))
                {
                    btn杯數1減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數1 = 0;
                    tb杯數1.Text = "0";
                }
            }
            else
            {
                杯數1 = 0;                
            }
            計算總價();
        }

        private void btn杯數2減_Click(object sender, EventArgs e)
        {
            杯數2 -= 1;
            if (杯數2 < 0)
            {
                杯數2 = 0;
                btn杯數2減.Enabled = false;
            }
            tb杯數2.Text = 杯數2.ToString();
        }

        private void btn杯數2加_Click(object sender, EventArgs e)
        {
            杯數2 += 1;
            btn杯數2減.Enabled = true;
            tb杯數2.Text = 杯數2.ToString();
        }

        private void tb杯數2_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數2.Text != "")
            {
                // Tryparse 傳址呼叫  若轉換失敗 out允許不回傳值(Null) ref不允許為空
                
                bool ifNum = System.Int32.TryParse(tb杯數2.Text, out 杯數2);
                if ((ifNum == true) && (杯數2 >= 0))
                {
                    btn杯數2減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數2 = 0;
                    tb杯數2.Text = "0";
                }
            }
            else
            {
                杯數2 = 0;
            }
            計算總價();
        }

        private void btn第二件六折_Click(object sender, EventArgs e)
        {
            tb折數.Text = "10.0";
            同品項1總價 = 售價1 * 杯數1 - (杯數1 / 2) * 售價1 * 0.4;
            同品項2總價 = 售價2 * 杯數2 - (杯數2 / 2) * 售價2 * 0.4;
            同品項3總價 = 售價3 * 杯數3 - (杯數3 / 2) * 售價3 * 0.4;
            同品項4總價 = 售價4 * 杯數4 - (杯數4 / 2) * 售價4 * 0.4;
            同品項5總價 = 售價5 * 杯數5 - (杯數5 / 2) * 售價5 * 0.4;

            折扣總價 = 同品項1總價 + 同品項2總價 + 同品項3總價 + 同品項4總價 + 同品項5總價;

            
            lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
            

        }

        private void btn買三送一_Click(object sender, EventArgs e)
        {

            折數 = 10.0;
            int x = (杯數1 + 杯數2 + 杯數3 + 杯數4 + 杯數5) / 4;
            if (x == 0) 
                return;

            int[] 杯數 = new int[5];
            杯數[0] = 杯數1;
            杯數[1] = 杯數2;
            杯數[2] = 杯數3;
            杯數[3] = 杯數4;
            杯數[4] = 杯數5;

            double[] 售價 = new double[5];
            售價[0] = 售價1;
            售價[1] = 售價2;
            售價[2] = 售價3;
            售價[3] = 售價4;
            售價[4] = 售價5;


            for (int i=0;i<5; i++)
            {
                x = x - 杯數[i];
                if (x >= 0)
                    杯數[i] = 0;
                else
                {
                    杯數[i] = -x;
                    break;
                }
            }
            折扣總價 = 0;
            for (int i = 0; i < 5; i++)
            折扣總價 += 杯數[i] * 售價[i];
            lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);

            /*
            tb折數.Text = "10.0";

            int x;
            x = (杯數1 + 杯數2 + 杯數3 + 杯數4 + 杯數5)/4;

            if (x == 0){MessageBox.Show("杯數數量有誤");}
            else
            {
                if (杯數1 >= 1)
                {
                    if (x - 杯數1 <= 0)
                    {
                        買一送一1總價 = 售價1 * (杯數1 - x);
                        買一送一2總價 = 售價2 * 杯數2;
                        買一送一3總價 = 售價3 * 杯數3;
                        買一送一4總價 = 售價4 * 杯數4;
                        買一送一5總價 = 售價5 * 杯數5;

                        折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                        lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                    }
                    else
                    {
                        if (x - 杯數1 - 杯數2 <= 0)
                        {
                            買一送一1總價 = 售價1 * 0;
                            買一送一2總價 = 售價2 * (杯數2 - x + 杯數1);
                            買一送一3總價 = 售價3 * 杯數3;
                            買一送一4總價 = 售價4 * 杯數4;
                            買一送一5總價 = 售價5 * 杯數5;

                            折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                            lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                        }
                        else
                        {
                            if (x - 杯數1 - 杯數2 - 杯數3 <= 0)
                            {
                                買一送一1總價 = 售價1 * 0;
                                買一送一2總價 = 售價2 * 0;
                                買一送一3總價 = 售價3 * (杯數3 - x + 杯數1 + 杯數2);
                                買一送一4總價 = 售價4 * 杯數4;
                                買一送一5總價 = 售價5 * 杯數5;

                                折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                            }
                            else
                            {
                                if (x - 杯數1 - 杯數2 - 杯數3 - 杯數4 <= 0)
                                {
                                    買一送一1總價 = 售價1 * 0;
                                    買一送一2總價 = 售價2 * 0;
                                    買一送一3總價 = 售價3 * 0;
                                    買一送一4總價 = 售價4 * (杯數4 - x + 杯數1 + 杯數2 + 杯數3);
                                    買一送一5總價 = 售價5 * 杯數5;

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                                else
                                {
                                    買一送一1總價 = 售價1 * 0;
                                    買一送一2總價 = 售價2 * 0;
                                    買一送一3總價 = 售價3 * 0;
                                    買一送一4總價 = 售價4 * 0;
                                    買一送一5總價 = 售價5 * (杯數5 - x + 杯數1 + 杯數2 + 杯數3 + 杯數4);

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (杯數2 >= 1)
                    {
                        if (x - 杯數2 <= 0)
                        {

                            買一送一2總價 = 售價2 * (杯數2 - x);
                            買一送一3總價 = 售價3 * 杯數3;
                            買一送一4總價 = 售價4 * 杯數4;
                            買一送一5總價 = 售價5 * 杯數5;

                            折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                            lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                        }
                        else
                        {
                            if (x - 杯數2 - 杯數3 <= 0)
                            {
                                買一送一2總價 = 售價2 * 0;
                                買一送一3總價 = 售價3 * (杯數3 - x + 杯數2);
                                買一送一4總價 = 售價4 * 杯數4;
                                買一送一5總價 = 售價5 * 杯數5;

                                折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                            }
                            else
                            {
                                if (x - 杯數2 - 杯數3 - 杯數4 <= 0)
                                {
                                    買一送一2總價 = 售價2 * 0;
                                    買一送一3總價 = 售價3 * 0;
                                    買一送一4總價 = 售價4 * 杯數4 - x + 杯數2 + 杯數3;
                                    買一送一5總價 = 售價5 * 杯數5;

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                                else
                                {
                                    買一送一2總價 = 售價2 * 0;
                                    買一送一3總價 = 售價3 * 0;
                                    買一送一4總價 = 售價4 * 0;
                                    買一送一5總價 = 售價5 * 杯數5 - x + 杯數2 + 杯數3 + 杯數4;

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (杯數3 >= 1)
                        {
                            if (x - 杯數3 <= 0)
                            {
                                買一送一3總價 = 售價3 * (杯數3 - x);
                                買一送一4總價 = 售價4 * 杯數4;
                                買一送一5總價 = 售價5 * 杯數5;

                                折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                            }
                            else
                            {
                                if (x - 杯數3 - 杯數4 <= 0)
                                {
                                    買一送一3總價 = 售價3 * 0;
                                    買一送一4總價 = 售價4 * (杯數4-x+杯數3);
                                    買一送一5總價 = 售價5 * 杯數5;

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                                else
                                {
                                    買一送一5總價 = 售價5 * (杯數5-x);

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                            }
                        }
                        else
                        {
                            if (杯數4 >= 1)
                            {
                                if (x - 杯數4 <= 0)
                                {

                                    買一送一4總價 = 售價4 * (杯數4 - x);
                                    買一送一5總價 = 售價5 * 杯數5;

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                                else
                                {
                                    買一送一4總價 = 售價4 * 0;
                                    買一送一5總價 = 售價5 * (杯數5 - x);

                                    折扣總價 = 買一送一1總價 + 買一送一2總價 + 買一送一3總價 + 買一送一4總價 + 買一送一5總價;
                                    lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                                }
                            }
                            else
                            {
                                買一送一4總價 = 售價4 * 0;
                                買一送一5總價 = 售價5 * (杯數5 - x);

                                折扣總價 = 買一送一4總價 + 買一送一5總價;
                                lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
                            }
                        }
                    }
                }

                

            }
            */
























        }

        private void btn杯數3減_Click(object sender, EventArgs e)
        {
            杯數3 -= 1;
            if (杯數3 < 0)
            {
                杯數3 = 0;
                btn杯數3減.Enabled = false;
            }
            tb杯數3.Text = 杯數3.ToString();
        }

        private void btn杯數3加_Click(object sender, EventArgs e)
        {
            杯數3 += 1;
            btn杯數3減.Enabled = true;
            tb杯數3.Text = 杯數3.ToString();
        }

        private void tb杯數3_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數3.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數3.Text, out 杯數3);
                if ((ifNum == true) && (杯數3 >= 0))
                {
                    btn杯數3減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數3 = 0;
                    tb杯數3.Text = "0";
                }
            }
            else
            {
                杯數3 = 0;
            }
            計算總價();
        }

        private void btn杯數4減_Click(object sender, EventArgs e)
        {
            杯數4 -= 1;
            if (杯數4 < 0)
            {
                杯數4 = 0;
                btn杯數4減.Enabled = false;
            }
            tb杯數4.Text = 杯數4.ToString();
        }

        private void btn杯數4加_Click(object sender, EventArgs e)
        {
            杯數4 += 1;
            btn杯數4減.Enabled = true;
            tb杯數4.Text = 杯數4.ToString();
        }

        private void tb杯數4_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數4.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數4.Text, out 杯數4);
                if ((ifNum == true) && (杯數4 >= 0))
                {
                    btn杯數4減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數4 = 0;
                    tb杯數4.Text = "0";
                }
            }
            else
            {
                杯數4 = 0;
            }
            計算總價();
        }

        private void btn杯數5減_Click(object sender, EventArgs e)
        {
            杯數5 -= 1;
            if (杯數5 < 0)
            {
                杯數5 = 0;
                btn杯數5減.Enabled = false;
            }
            tb杯數5.Text = 杯數5.ToString();
        }

        private void btn杯數5加_Click(object sender, EventArgs e)
        {
            杯數5 += 1;
            btn杯數5減.Enabled = true;
            tb杯數5.Text = 杯數5.ToString();
        }

        private void tb杯數5_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數5.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數5.Text, out 杯數5);
                if ((ifNum == true) && (杯數5 >= 0))
                {
                    btn杯數5減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數5 = 0;
                    tb杯數5.Text = "0";
                }
            }
            else
            {
                杯數5 = 0;
            }
            計算總價();
        }

        private void tb折數_TextChanged(object sender, EventArgs e)
        {
            if(tb折數.Text != "")
            {
                bool ifNum = System.Double.TryParse(tb折數.Text, out 折數);

                if (ifNum == true)
                {
                    if ((折數 >= 0.0) && (折數 <= 10.0))
                    {
                        //合理折數
                    }
                    else
                    {
                        MessageBox.Show("折數輸入錯誤(0.0-10.0)");
                        tb折數.Text = "";
                        折數 = 10.0;
                    }
                }
                else
                {
                    MessageBox.Show("折數輸入錯誤(0.0-10.0)");
                    tb折數.Text = "";
                    折數 = 10.0;
                }
            }
            else
            {
                折數 = 10.0;
            }
            計算總價();
        }

        private void btn列印訂購單_Click(object sender, EventArgs e)
        {
            DialogResult drResult;
            drResult = MessageBox.Show("您確認送出訂購單?", "訂單確認", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(drResult == DialogResult.No)
            {
                //取消送出
            }
            else
            {
                //確認訂單
                string strOrder = "***** III冷飲店訂購單 ******\n";
                strOrder += "--------------------\n";
                if (杯數1 > 0)
                {
                    strOrder += lbl品名1.Text + ":" + lbl售價1.Text + "x" + tb杯數1.Text + "=" + 品項1總價.ToString() + "\n";
                }
                if (杯數2 > 0)
                {
                    strOrder += lbl品名2.Text + ":" + lbl售價2.Text + "x" + tb杯數2.Text + "=" + 品項2總價.ToString() + "\n";
                }
                if (杯數3 > 0)
                {
                    strOrder += lbl品名3.Text + ":" + lbl售價3.Text + "x" + tb杯數3.Text + "=" + 品項3總價.ToString() + "\n";
                }
                if (杯數4 > 0)
                {
                    strOrder += lbl品名4.Text + ":" + lbl售價4.Text + "x" + tb杯數4.Text + "=" + 品項4總價.ToString() + "\n";
                }
                if (杯數5 > 0)
                {
                    strOrder += lbl品名5.Text + ":" + lbl售價5.Text + "x" + tb杯數5.Text + "=" + 品項5總價.ToString() + "\n";
                }
                strOrder += "---------------------\n";
                if (折數 < 10.0)
                {
                    strOrder += "折數" + string.Format("{0:F2}", 折數);
                }
                strOrder += "訂單總價" + string.Format("{0:C}", 總價 + "\n");
                strOrder += "折扣總價" + string.Format("{0:C}", 折扣總價 + "\n");
                strOrder += string.Format("{0:D}", DateTime.Now)+"\n";
                strOrder += string.Format("{0:T}", DateTime.Now )+"\n";
                MessageBox.Show(strOrder, "訂單明細", MessageBoxButtons.OK);

            }
        }





        void 計算總價()
        {
            品項1總價 = 售價1 * 杯數1;
            品項2總價 = 售價2 * 杯數2;
            品項3總價 = 售價3 * 杯數3;
            品項4總價 = 售價4 * 杯數4;
            品項5總價 = 售價5 * 杯數5;

            總價 = 品項1總價 + 品項2總價 + 品項3總價 + 品項4總價 + 品項5總價;
            折扣總價 = 總價 * 折數 / 10;

            lbl訂單總價.Text = string.Format("{0:C}", 總價);
            lbl折扣總價.Text = string.Format("{0:C}", 折扣總價);
        }

        
    }
}
