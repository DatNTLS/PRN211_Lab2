using System;
using Lab2_ADO.DataAccess;
using Lab2_ADO.Logics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2_ADO.Models;

namespace Lab2_ADO
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void LoadDataForDGV()
        {
            dataGridView1.DataSource = CourseManager.GetAllCoursesFromDB();
            dataGridView1.Columns["CourseId"].Visible = false;
            dataGridView1.Columns["SubjectId"].Visible = false;
            dataGridView1.Columns["InstructorId"].Visible = false;
            dataGridView1.Columns["TermId"].Visible = false;
            dataGridView1.Columns["CampusId"].Visible = false;
        }

        private void LoadListSearch(ComboBox box, dynamic list, dynamic choice, string name, string id)
        {
            list.AddRange(choice);
            box.DataSource = list;
            box.DisplayMember = name;
            box.ValueMember = id;
        }

        private void LoadListBox(ComboBox box, dynamic obj, string name, string id)
        {
            box.DataSource = obj;
            box.DisplayMember = name;
            box.ValueMember = id;
        }

        private void RefreshForm()
        {
            textBox1.Text = textBox2.Text = "";
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = comboBox4.SelectedIndex
                = comboBox5.SelectedIndex = comboBox6.SelectedIndex = 0;
            LoadDataForDGV();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadDataForDGV();

            //List to search by subject
            //LoadListBox(comboBox1, SubjectManager.GetAllSubjectsFromDB(), "SubjectName", "SubjectId");

            List<Subject> listS = new List<Subject>();
            listS.Add(new Subject(0, "", "All Subjects", 1));
            LoadListSearch(comboBox1, listS, SubjectManager.GetAllSubjectsFromDB(), "SubjectName", "SubjectId");

            //List to search by instructor
            //LoadListBox(comboBox2, InstructorManager.GetAllInstructorsFromDB(), "InstructorLastName", "InstructorId");

            List<Instructor> listI = new List<Instructor>();
            listI.Add(new Instructor(0, "", "", "All Instructors", 1));
            LoadListSearch(comboBox2, listI, InstructorManager.GetAllInstructorsFromDB(), "InstructorLastName", "InstructorId");

            //List to choose subject
            LoadListBox(comboBox3, SubjectManager.GetAllSubjectsFromDB(), "SubjectName", "SubjectId");

            //List to choose instructor
            LoadListBox(comboBox4, InstructorManager.GetAllInstructorsFromDB(), "InstructorLastName", "InstructorId");

            //List to choose Term
            LoadListBox(comboBox5, TermManager.GetAllTermsFromDB(), "TermName", "TermId");

            //List to choose Campus
            LoadListBox(comboBox6, CampusManager.GetAllCampusesFromDB(), "CampusName", "CampusId");



        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.CourseCode = textBox1.Text;
            c.CourseDescription = textBox2.Text;
            c.SubjectId = Convert.ToInt32(comboBox3.SelectedValue);
            c.InstructorId = Convert.ToInt32(comboBox4.SelectedValue);
            c.TermId = Convert.ToInt32(comboBox5.SelectedValue);
            c.CampusId = Convert.ToInt32(comboBox6.SelectedValue);
            CourseManager.AddCourseDB(c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId, c.TermId, c.CampusId);
            MessageBox.Show("Add Successfully !");
            LoadDataForDGV();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int code = Convert.ToInt32(row.Cells[0].Value.ToString());
                    CourseManager.DeleteCourseDB(code);
                    MessageBox.Show("Delete Successfully !");
                    LoadDataForDGV();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Delete !");
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int code = Convert.ToInt32(row.Cells[0].Value.ToString());
                Course c = CourseManager.GetCourseByIdDB(code);
                c.CourseCode = textBox1.Text.Trim();
                c.CourseDescription = textBox2.Text.Trim();
                c.SubjectId = Convert.ToInt32(comboBox3.SelectedValue);
                c.InstructorId = Convert.ToInt32(comboBox4.SelectedValue);
                c.TermId = Convert.ToInt32(comboBox5.SelectedValue);
                c.CampusId = Convert.ToInt32(comboBox6.SelectedValue);
                CourseManager.UpdateCourseDB(code, c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId, c.TermId, c.CampusId);
                MessageBox.Show("Update Successfully !");
                LoadDataForDGV();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                Int32.TryParse(comboBox1.SelectedValue.ToString(), out id);
                if (id == 0)
                {
                    dataGridView1.DataSource = CourseManager.GetAllCoursesFromDB();
                } else
                {
                    dataGridView1.DataSource = CourseManager.SearchBySubjectsDB(id);
                }
            }
            catch (Exception)
            {

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                Int32.TryParse(comboBox2.SelectedValue.ToString(), out id);
                if (id == 0)
                {
                    dataGridView1.DataSource = CourseManager.GetAllCoursesFromDB();
                } else
                {
                    dataGridView1.DataSource = CourseManager.SearchByInstructorsDB(id);
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int courseId = (int)dataGridView1.Rows[e.RowIndex].Cells["CourseId"].Value;
                Course course = CourseManager.GetCourseByIdDB(courseId);
                textBox1.Text = course.CourseCode;
                textBox2.Text = course.CourseDescription;
                comboBox3.SelectedValue = course.SubjectId;
                comboBox4.SelectedValue = course.InstructorId;
                comboBox5.SelectedValue = course.TermId;
                comboBox6.SelectedValue = course.CampusId;
            }
            catch (Exception)
            {

            }
        }
    }
}
