﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical
{
    public partial class PatientHistory : Form
    {
        public PatientHistory(int patient_id)
        {
            InitializeComponent();
            //Setting Custom Styles to the Data Grid View
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ddd");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            FillPatientsHistoryGridView(patient_id);
        }

        public void FillPatientsHistoryGridView(int patient_id)
        {
            Helper.sqliteConn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID, PATIENT_ID, APPOINTMENTTYPE, DATE(APPOINTMENT_DATE) FROM PATIENT_HISTORY where PATIENT_ID = " + patient_id, Helper.sqliteConn);

            DataTable dataTable = new DataTable();

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;

            Helper.sqliteConn.Close();
        }
    }
}
