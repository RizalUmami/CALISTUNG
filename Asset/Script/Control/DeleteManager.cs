using UnityEngine;
using MySql.Data.MySqlClient;

public class DeleteManager : MonoBehaviour
{
    public DualPopupManager popupManager;

    public void DeleteKolomSiswa(string kolom, int id)
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            try
            {
                conn.Open();
                string query = $"UPDATE siswa SET {kolom} = NULL WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                popupManager.ShowSuccess($"Kolom {kolom} berhasil dikosongkan!");
            }
            catch (MySqlException ex)
            {
                popupManager.ShowError("Gagal menghapus kolom: " + ex.Message);
            }
        }
    }
}
