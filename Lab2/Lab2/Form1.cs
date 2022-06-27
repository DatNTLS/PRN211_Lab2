using Lab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void LoadDataForDGV()
        {
            using (var context = new APContext())
            {
                dataGridView.DataSource = context.Courses
                    .Select(x => new
                    {
                        x.CourseId,
                        x.CourseCode,
                        x.CourseDescription,
                        x.Subject.SubjectName,
                        x.Instructor.InstructorLastName,
                        x.Term.TermName,
                        x.Campus.CampusName
                    })
                    .ToList();
            }
            dataGridView.Columns["CourseId"].Visible = false;

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
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = comboBox4.SelectedIndex = 0;
            boxSubject.SelectedIndex = boxInstructors.SelectedIndex = 0;
            LoadDataForDGV();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadDataForDGV();
            using (var context = new APContext())
            {
                //List to search by subject
                //LoadListBox(boxSubject, context.Subjects.ToList(), "SubjectName", "SubjectId");
                List<Subject> listS = new List<Subject>();
                Subject s = new Subject();
                s.SubjectId = 0;
                s.SubjectCode = "";
                s.SubjectName = "All Subjects";
                s.DepartmentId = 1;
                listS.Add(s);
                LoadListSearch(boxSubject, listS, context.Subjects.ToList(), "SubjectName", "SubjectId");

                //List to search by instructor
                //LoadListBox(boxInstructors, context.Instructors.ToList(), "InstructorLastName", "InstructorId");
                List<Instructor> listI = new List<Instructor>();
                Instructor i = new Instructor();
                i.InstructorId = 0;
                i.InstructorFirstName = i.InstructorMidName = "";
                i.InstructorLastName = "All Instructors";
                i.DepartmentId = 1;
                listI.Add(i);
                LoadListSearch(boxInstructors, listI, context.Instructors.ToList(), "InstructorLastName", "InstructorId");
                //List to choose subject
                LoadListBox(comboBox1, context.Subjects.ToList(), "SubjectName", "SubjectId");

                //List to choose instructor
                LoadListBox(comboBox2, context.Instructors.ToList(), "InstructorLastName", "InstructorId");

                //List to choose Term
                LoadListBox(comboBox3, context.Terms.ToList(), "TermName", "TermId");

                //List to choose Campus
                LoadListBox(comboBox4, context.Campuses.ToList(), "CampusName", "CampusId");
            }

        }

        private void add_Click(object sender, EventArgs e)
        {

            using (var context = new APContext())
            {
                Course c = new Course();
                c.CourseCode = textBox1.Text.Trim();
                c.CourseDescription = textBox2.Text.Trim();
                c.SubjectId = Convert.ToInt32(comboBox1.SelectedValue);
                c.InstructorId = Convert.ToInt32(comboBox2.SelectedValue);
                c.TermId = Convert.ToInt32(comboBox3.SelectedValue);
                c.CampusId = Convert.ToInt32(comboBox4.SelectedValue);
                context.Courses.Add(c);
                context.SaveChanges();
                MessageBox.Show("Add Successfully !");
                LoadDataForDGV();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            using (var context = new APContext())
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        int code = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Course c = context.Courses.First(x => x.CourseId == code);
                        context.Courses.Remove(c);
                        context.SaveChanges();
                        MessageBox.Show("Delete Successfully !");
                        LoadDataForDGV();
                        RefreshForm();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't Delete !");
                }
                //var mess = MessageBox.Show("Are you sure to delete ?", "Confirm", MessageBoxButtons.YesNo);
                //if (mess == DialogResult.OK)
                //{
                //    MessageBox.Show("Delete Successfully !");
                //    context.SaveChanges();
                //    LoadDataForDGV();
                //    RefreshForm();
                //}

            }

        }

        private void update_Click(object sender, EventArgs e)
        {

            using (var context = new APContext())
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int code = Convert.ToInt32(row.Cells[0].Value.ToString());
                    Course c = context.Courses.First(x => x.CourseId == code);
                    c.CourseCode = textBox1.Text.Trim();
                    c.CourseDescription = textBox2.Text.Trim();
                    c.SubjectId = Convert.ToInt32(comboBox1.SelectedValue);
                    c.InstructorId = Convert.ToInt32(comboBox2.SelectedValue);
                    c.TermId = Convert.ToInt32(comboBox3.SelectedValue);
                    c.CampusId = Convert.ToInt32(comboBox4.SelectedValue);
                    context.Courses.Update(c);
                }
                context.SaveChanges();
                MessageBox.Show("Update Successfully !");
                LoadDataForDGV();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void boxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var context = new APContext())
            {
                try
                {
                    int id;
                    Int32.TryParse(boxSubject.SelectedValue.ToString(), out id);
                    if (id != 0)
                    {
                        dataGridView.DataSource = context.Courses
                        .Where(x => x.SubjectId == id)
                        .Select(x => new
                        {
                            x.CourseId,
                            x.CourseCode,
                            x.CourseDescription,
                            x.Subject.SubjectName,
                            x.Instructor.InstructorLastName,
                            x.Term.TermName,
                            x.Campus.CampusName
                        })
                        .ToList();
                    } else
                    {
                        dataGridView.DataSource = context.Courses
                            .Select(x => new
                            {
                                x.CourseId,
                                x.CourseCode,
                                x.CourseDescription,
                                x.Subject.SubjectName,
                                x.Instructor.InstructorLastName,
                                x.Term.TermName,
                                x.Campus.CampusName
                            })
                            .ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fail.");
                }
            }

        }

        private void boxInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new APContext())
            {
                try
                {
                    int id;
                    Int32.TryParse(boxInstructors.SelectedValue.ToString(), out id);
                    if (id != 0)
                    {
                        dataGridView.DataSource = context.Courses
                        .Where(x => x.InstructorId == id)
                        .Select(x => new
                        {
                            x.CourseId,
                            x.CourseCode,
                            x.CourseDescription,
                            x.Subject.SubjectName,
                            x.Instructor.InstructorLastName,
                            x.Term.TermName,
                            x.Campus.CampusName
                        })
                        .ToList();
                    }
                    else
                    {
                        dataGridView.DataSource = context.Courses
                            .Select(x => new
                            {
                                x.CourseId,
                                x.CourseCode,
                                x.CourseDescription,
                                x.Subject.SubjectName,
                                x.Instructor.InstructorLastName,
                                x.Term.TermName,
                                x.Campus.CampusName
                            })
                            .ToList();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Fail.");
                }
            }

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new APContext())
            {
                try
                {
                    int courseId = (int)dataGridView.Rows[e.RowIndex].Cells["CourseId"].Value;
                    var course = context.Courses.Find(courseId);
                    textBox1.Text = course.CourseCode;
                    textBox2.Text = course.CourseDescription;
                    comboBox1.SelectedValue = course.SubjectId;
                    comboBox2.SelectedValue = course.InstructorId;
                    comboBox3.SelectedValue = course.TermId;
                    comboBox4.SelectedValue = course.CampusId;
                }
                catch (Exception)
                {

                }
            }

        }

    }
}
