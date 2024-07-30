using Bridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Services
{
    public interface IEmailService
    {
        Task<bool> SendReleaseNotesByJiraId(SendReleaseNotesRequest request, CancellationToken ct = default);
    }
}
