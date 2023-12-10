





using System.Runtime.ExceptionServices;

namespace keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repo.CreateKeep(keepData);
        return keep;
    }

    internal string DestroyKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId, userId);
        if (keep.CreatorId != userId)
        {
            throw new Exception($"You are not the owner of the keep with the ID of {keepId}");
        }

        _repo.DestroyKeep(keepId);
        return "Keep has been deleted";
    }

    internal Keep EditKeep(int keepId, Account userInfo, Keep keepData)
    {
        Keep originalKeep = GetKeepById(keepId, userInfo.Id);
        if (userInfo.Id != originalKeep.CreatorId)
        {
            throw new Exception($"Keep with the edit of {keepId} is not yours to edit. Please log in as the correct user.");
        }
        originalKeep.Name = keepData.Name ?? originalKeep.Name;
        originalKeep.Description = keepData.Description ?? originalKeep.Description;
        originalKeep.Img = keepData.Img ?? originalKeep.Img;

        Keep keep = _repo.EditKeep(originalKeep);
        return keep;
    }

    internal Keep GetKeepById(int keepId, string userId)
    {
        Keep keep = _repo.GetKeepById(keepId);
        if (keep == null)
        {
            throw new Exception($"The keep with the id of {keepId} does not exist");
        }
        return keep;
    }

    internal Keep GetKeepByIdAndIncrementVisits(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId, userId);
        keep.Views++;
        _repo.EditKeep(keep);
        return keep;
    }

    internal List<Keep> GetKeeps()
    {
        List<Keep> keeps = _repo.GetKeeps();
        return keeps;
    }

    internal List<Keep> GetKeepsByProfileId(string profileId)
    {
        List<Keep> keeps = _repo.GetKeepsByProfileId(profileId);
        return keeps;
    }
}