using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class XuLyFile
    {
        public static void LayDuLieuTuFile(List<contact> danhba)
        {
            using (StreamReader reader = new StreamReader("contacts.txt"))
            {
                string input = reader.ReadLine(); // doc so danh ba

                int soDB;
                if (!int.TryParse(input, out soDB)) return; // neu khong phai so thi thoat

                contact c;
                for (int i = 0; i < soDB; i++) // lap qua cac dong theo so danh ba
                {
                    input = reader.ReadLine(); // doc mot dong

                    // tach du lieu trong moi dong va tao ra doi tuong Contact moi
                    if (!TachGiaTri(input, out c)) return;

                    danhba.Add(c); // them Tai khoan moi vao danh sach
                }
            }
        }

        // Ham xu ly tach dong thong tin lien lac
        // va tra ra mot Contact moi
        private static bool TachGiaTri(string input, out contact c)
        {
            // xu ly tham so out, phong truong hop doc du lieu bi loi
            c = null;

            string[] inputs = input.Split('-');

            // chuỗi phải chứa 4 thanh phan
            if (inputs.Length != 4) return false;

            string ho = inputs[0]; // thanh phan dau tien la ho
            string ten = inputs[1]; // thanh phan thu hai la ten
            string diachi = inputs[2]; // thanh phan thu ba la diachi
            string sdt = inputs[3]; // thanh phan thu tu la sdt

            c = new contact(ho, ten, diachi, sdt);
            return true;
        }

        // Ham xu ly luu danh sach thong tin lien lac ra file
        public static bool LuuDuLieuRaFile(List<contact> danhba)
        {
            using (StreamWriter writer = new StreamWriter("contacts.txt"))
            {
                if (writer == null) return false;

                // dong dau tien la so luong danh ba
                writer.WriteLine(danhba.Count);

                // cac dong tiep theo thong tin danh ba
                foreach (contact c in danhba)
                    writer.WriteLine(string.Format("{0}-{1}-{2}-{3}",
                                                    c.GetHo(),
                                                    c.GetTen(),
                                                    c.GetDiaChi(),
                                                    c.GetSDT()));
            }
            return true;
        }
    }
}