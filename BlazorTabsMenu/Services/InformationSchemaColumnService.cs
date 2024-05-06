using BlazorTabsMenu.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services;

public class InformationSchemaColumnService : IInformationSchemaColumnService
{
    private readonly InformationSchemaColumnContext _context;
    public InformationSchemaColumnService()
    {
        _context = new InformationSchemaColumnContext();
    }

    public List<InformationSchemaColumn> Get()
    {

        return [.. _context.InformationSchemaColumns];
    }


    public async Task<List<InformationSchemaColumn>> GetAsync()
    {
        var retval = 
            await _context.InformationSchemaColumns.ToListAsync();        
        return retval;
    }
}


