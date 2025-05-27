using UnityEngine;
using MySql.Data.MySqlClient;

public class InsertManager : MonoBehaviour
{
    public DualPopupManager popupManager;

    public void InsertSiswa(string nama, string email, string panggilan, string asal, string gender)
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            try
            {
                conn.Open();
                string query = @"
                    INSERT INTO siswa 
                        (nama, email, namapanggilan, asalsekolah, gender) 
                    VALUES 
                        (@nama, @email, @panggilan, @asal, @gender)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@panggilan", panggilan);
                    cmd.Parameters.AddWithValue("@asal", asal);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.ExecuteNonQuery();
                }

                popupManager.ShowSuccess("Data berhasil ditambahkan!");
            }
            catch (MySqlException ex)
            {
                popupManager.ShowError("Gagal menambahkan data: " + ex.Message);
                Debug.Log("Gagal menambahkan data: " + ex.Message);
            }
        }
    }
}
