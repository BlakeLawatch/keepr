namespace keepr.Models;

public class VaultKeep : RepoItem<int>
{
    public string CreatorId { get; set; }
    public int VaultID { get; set; }
    public int KeepID { get; set; }
    public Profile Creator { get; set; }
}