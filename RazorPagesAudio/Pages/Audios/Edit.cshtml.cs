using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudio.Data;
using RazorPagesAudio.Models;

namespace RazorPagesAudio.Pages.Audios
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesAudio.Data.RazorPagesAudioContext _context;

        public EditModel(RazorPagesAudio.Data.RazorPagesAudioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audio Audio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audio =  await _context.Audio.FirstOrDefaultAsync(m => m.Id == id);
            if (audio == null)
            {
                return NotFound();
            }
            Audio = audio;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Audio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudioExists(Audio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AudioExists(int id)
        {
            return _context.Audio.Any(e => e.Id == id);
        }
    }
}
