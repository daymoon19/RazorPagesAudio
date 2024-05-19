using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudio.Data;
using RazorPagesAudio.Models;

namespace RazorPagesAudio.Pages.Audios
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAudio.Data.RazorPagesAudioContext _context;

        public IndexModel(RazorPagesAudio.Data.RazorPagesAudioContext context)
        {
            _context = context;
        }

        public IList<Audio> Audio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Audio = await _context.Audio.ToListAsync();
        }
    }
}
