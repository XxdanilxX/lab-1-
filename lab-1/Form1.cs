using System.Windows.Forms;

namespace lab_1
{
    public partial class Form1 : Form
    {
        private int comparisonCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        // ����� ��� ��������� ���������� �������� ������
        private void TwoPhaseMergeSort(string inputFilePath, string outputFilePath)
        {
            // �������� �� �������� �������� �����
            if (!File.Exists(inputFilePath))
            {
                CreateRandomFile(inputFilePath);
            }

            string tempFile1 = "temp1.txt";
            string tempFile2 = "temp2.txt";

            // ��������� ����� �� �� �������
            SplitFile(inputFilePath, tempFile1, tempFile2);

            // ��'������� ���� ����� � ��������� ������
            MergeFiles(tempFile1, tempFile2, outputFilePath);

            // ³���������� �������� ����������
            DisplayFile(inputFilePath, outputFilePath);
        }

        // ����� ��� ��������� �����, ���� ���� �������
        private void CreateRandomFile(string filePath)
        {
            Random rand = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < 20; i++)  // ��������� 20 ���������� �����
                {
                    writer.WriteLine(rand.Next(1, 101));  // ����� �� 1 �� 100
                }
            }
            MessageBox.Show($"���� {filePath} �� �������, ���� ��� ��������� � ����������� ������.");
        }

        private void SplitFile(string inputFilePath, string tempFile1, string tempFile2)
        {
            // ����� �������� ����� �� �� �������
            using (var reader = new StreamReader(inputFilePath))
            using (var writer1 = new StreamWriter(tempFile1))
            using (var writer2 = new StreamWriter(tempFile2))
            {
                bool writeToFirst = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (writeToFirst)
                    {
                        writer1.WriteLine(line);
                    }
                    else
                    {
                        writer2.WriteLine(line);
                    }
                    writeToFirst = !writeToFirst;
                }
            }
        }

        private void MergeFiles(string tempFile1, string tempFile2, string outputFilePath)
        {
            // ����� ������ ���� ������ �����
            using (var writer = new StreamWriter(outputFilePath))
            using (var reader1 = new StreamReader(tempFile1))
            using (var reader2 = new StreamReader(tempFile2))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    comparisonCount++;
                    if (string.Compare(line1, line2) < 0)
                    {
                        writer.WriteLine(line1);
                        line1 = reader1.ReadLine();
                    }
                    else
                    {
                        writer.WriteLine(line2);
                        line2 = reader2.ReadLine();
                    }
                }

                // �������� ������� � ������� ��� ������� �����
                while (line1 != null)
                {
                    writer.WriteLine(line1);
                    line1 = reader1.ReadLine();
                }

                while (line2 != null)
                {
                    writer.WriteLine(line2);
                    line2 = reader2.ReadLine();
                }
            }
        }

        private void DisplayFile(string inputFilePath, string outputFilePath)
        {
            // ������� DataGridView ����� ������������ ����� �����
            dataGridView1.Rows.Clear();

            // ���� ������� �� �� �������, ������ �� ������� ��� "�� ����" � "�� �����"
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("InitialColumn", "�� ����");
                dataGridView1.Columns.Add("SortedColumn", "�� �����");
            }

            // ������� �������� �� ���������� ���
            var initialLines = File.ReadAllLines(inputFilePath);
            var sortedLines = File.ReadAllLines(outputFilePath);

            // ³��������� ��� � DataGridView
            for (int i = 0; i < initialLines.Length; i++)
            {
                string initial = initialLines[i];
                string sorted = (i < sortedLines.Length) ? sortedLines[i] : string.Empty;

                // ������ ����� � ���������� �� ������������ ���������
                dataGridView1.Rows.Add(initial, sorted);
            }

            MessageBox.Show($"ʳ������ ��������: {comparisonCount}");
        }


        private void btnSort_Click(object sender, EventArgs e)
        {
            string inputFilePath = "C:\\Users\\Lenovo\\Desktop\\input.txt";  // ���� �� �������� �����
            string outputFilePath = "C:\\Users\\Lenovo\\Desktop\\output.txt";  // ���� �� ��������� �����
            TwoPhaseMergeSort(inputFilePath, outputFilePath);
            DisplayFile(inputFilePath, outputFilePath);  // ³��������� � ��������, � ���������� ���
        }


    }
}
