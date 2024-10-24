using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private List<Student> students; // Danh sách sinh viên

        public Form1()
        {
            InitializeComponent();
            students = new List<Student>(); // Khởi tạo danh sách sinh viên
            InitializeDataGridView(); // Thiết lập DataGridView
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGridView(); // Làm mới DataGridView khi form tải
        }

        private void InitializeDataGridView()
        {
            dataGridViewStudents.Columns.Add("studentID", "Mã Sinh Viên");
            dataGridViewStudents.Columns.Add("name", "Tên Sinh Viên");
            dataGridViewStudents.Columns.Add("class", "Lớp Học");
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Nút "Thêm"
        {
            var student = new Student
            {
                StudentID = textBoxStudentID.Text,
                Name = textBoxName.Text,
                Class = textBoxClass.Text
            };
            students.Add(student); // Thêm sinh viên vào danh sách
            RefreshDataGridView(); // Làm mới DataGridView
            ClearInputFields(); // Xóa các trường nhập liệu
        }

        private void buttonEdit_Click(object sender, EventArgs e) // Nút "Sửa"
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewStudents.SelectedRows[0];
                selectedRow.Cells["studentID"].Value = textBoxStudentID.Text;
                selectedRow.Cells["name"].Value = textBoxName.Text;
                selectedRow.Cells["class"].Value = textBoxClass.Text;

                var index = students.FindIndex(s => s.StudentID == selectedRow.Cells["studentID"].Value.ToString());
                students[index].Name = textBoxName.Text;
                students[index].Class = textBoxClass.Text;

                RefreshDataGridView(); // Làm mới DataGridView
                ClearInputFields(); // Xóa các trường nhập liệu
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) // Nút "Xóa"
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewStudents.SelectedRows[0];
                students.RemoveAll(s => s.StudentID == selectedRow.Cells["studentID"].Value.ToString());
                RefreshDataGridView(); // Làm mới DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }
        }

        private void RefreshDataGridView()
        {
            dataGridViewStudents.Rows.Clear(); // Xóa tất cả hàng hiện tại
            foreach (var student in students)
            {
                dataGridViewStudents.Rows.Add(student.StudentID, student.Name, student.Class); // Thêm hàng mới
            }
        }

        private void ClearInputFields()
        {
            textBoxStudentID.Clear();
            textBoxName.Clear();
            textBoxClass.Clear();
        }
    }

    public class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
