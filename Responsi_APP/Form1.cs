

namespace Responsi_APP
{
    using Npgsql;
    using System.Data;
    using System.Xml.Linq;
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=hervidatabase";
        //public static NpgsqlConnection conn = new Npgsql Connection(NpgsqlConnectionStringBuilder:connstring)
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        public string test;
        public Form1()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connstring);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();


               
                sql = @"select * from insert(:_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", textBox1.Text);
                if(textBox3.Text == "HR")
                {
                    test = "1";

                }
                else if (textBox3.Text == "ENG")
                {
                    test = "2";

                }
                else if (textBox3.Text == "DEV")
                {
                    test = "3";

                }
                else if (textBox3.Text == "PM")
                {
                    test = "4";

                }
                else if (textBox3.Text == "FIN")
                {
                    test = "5";

                }
                cmd.Parameters.AddWithValue("_id_dep", int.Parse(textBox3.Text));

                


                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data user berhasil diinputkan", "Selamat!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan diupdate", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Apakah benar Anda ingin menghapus data " + " ?", "Hapus data terkonfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)

             try
             {
                 conn.Open();
                 sql = @"select * from delete_id(:_id_karyawan)";
                 cmd = new NpgsqlCommand(sql, conn);
                 cmd.Parameters.AddWithValue("_id_karyawan", r.Cells["_id_karyawan"].Value.ToString());
                 if ((int)cmd.ExecuteScalar() == 1)
                 {
                     MessageBox.Show("Data Users Berhasil dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     conn.Close();

                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error:" + ex.Message, "Delete FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon Pilih baris data yang akan diupdate", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    sql = @"select * from st_update(:_id,:_name,:_alamat,:_no_handphone)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", r.Cells["_id"].Value.ToString());
                    cmd.Parameters.AddWithValue("_name", textBox1.Text);


                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Data Users Berhasil diupdate", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();

                        r = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "update FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                dataGridView1.DataSource = null;
                sql = "select * from select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dataGridView1.DataSource = dt;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "FAILL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = r.Cells["_nama"].Value.ToString();
    

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                dataGridView1.DataSource = null;
                sql = "select * from read_data_fix()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dataGridView1.DataSource = dt;



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "FAILL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}