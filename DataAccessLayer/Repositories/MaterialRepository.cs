// Repositories/MaterialRepository.cs
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

public class MaterialRepository : IMaterialRepository
{
    private readonly AppDbContext _context;

    public MaterialRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public IEnumerable<Material> GetAllMaterials()
    {
        return _context.Materials.Include(m => m.Course).ToList();
    }

    public Material GetMaterialsByCourseId(int id)
    {
        return _context.Materials.Include(m => m.Course).FirstOrDefault(m => m.Id == id);
    }

    public void AddMaterial(Material material)
    {
        _context.Materials.Add(material);
    }

    public void UpdateMaterial(Material material)
    {
        _context.Materials.Update(material);
    }

    public void DeleteMaterial(int id)
    {
        var material = GetMaterialsByCourseId(id);
        if (material != null)
        {
            _context.Materials.Remove(material);
        }
    }
}
