using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudio.Models;

namespace RazorPagesAudio.Data
{
    public class RazorPagesAudioContext : DbContext
    {
        public RazorPagesAudioContext (DbContextOptions<RazorPagesAudioContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAudio.Models.Audio> Audio { get; set; } = default!;
    }
}
