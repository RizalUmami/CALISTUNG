using UnityEngine;
using MySql.Data.MySqlClient;

public class UpdateManager : MonoBehaviour
{
    public DualPopupManager popupManager;

    public void UpdateSiswa(string kolom, string nilai, int id)
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            try
            {
                conn.Open();
                string query = $"UPDATE siswa SET {kolom} = @nilai WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nilai", nilai);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                popupManager.ShowSuccess($"Berhasil memperbarui kolom {kolom}!");
            }
            catch (MySqlException ex)
            {
                popupManager.ShowError("Gagal memperbarui data: " + ex.Message);
            }
        }
    }
}
