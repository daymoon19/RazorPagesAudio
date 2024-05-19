using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAudio.Data;
using RazorPagesAudio.Models;

namespace RazorPagesAudio.Pages.Audios
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAudio.Data.RazorPagesAudioContext _context;

        public CreateModel(RazorPagesAudio.Data.RazorPagesAudioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Audio Audio { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Audio.Add(Audio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
