using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KudumbashreeManagementSystem.Data;
using KudumbashreeManagementSystem.Models;

namespace KudumbashreeManagementSystem.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            // Include MeetingMembers and each Member so TotalContribution and member names are available
            return View(await _context.Meetings
                .Include(m => m.MeetingMembers)
                    .ThenInclude(mm => mm.Member)
                .ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.MeetingMembers)
                .ThenInclude(mm => mm.Member)
                .FirstOrDefaultAsync(m => m.MeetingId == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/UpdateMembers/5
        // Updates attendance and contribution amounts for meeting members
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMembers(int meetingId, List<MeetingMember> meetingMembers)
        {
            var meeting = await _context.Meetings.FindAsync(meetingId);
            if (meeting == null)
            {
                return NotFound();
            }

            if (meeting.IsFinalized)
            {
                // Do not allow updates to finalized meetings
                return RedirectToAction(nameof(Details), new { id = meetingId });
            }

            if (meetingMembers != null && meetingMembers.Count > 0)
            {
                foreach (var updated in meetingMembers)
                {
                    var entity = await _context.MeetingMembers.FindAsync(updated.Id);
                    if (entity != null)
                    {
                        entity.IsPresent = updated.IsPresent;
                        entity.ContributionAmount = updated.ContributionAmount;
                        _context.MeetingMembers.Update(entity);
                    }
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Meetings/Finalize/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalize(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            meeting.IsFinalized = true;
            _context.Update(meeting);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,MeetingDate,ExpectedAmount,Notes")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();

                // Fetch all members
                var members = await _context.Members.ToListAsync();

                // Create participation rows
                var meetingMembers = members.Select(m => new MeetingMember
                {
                    MeetingId = meeting.MeetingId,
                    MemberId = m.MemberId,
                    IsPresent = true,
                    ContributionAmount = meeting.ExpectedAmount
                }).ToList();

                _context.MeetingMembers.AddRange(meetingMembers);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = meeting.MeetingId });
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            if (meeting.IsFinalized)
            {
                // Redirect to details if meeting is finalized - editing not allowed
                return RedirectToAction(nameof(Details), new { id = meeting.MeetingId });
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingId,MeetingDate,ExpectedAmount,Notes")] Meeting meeting)
        {
            if (id != meeting.MeetingId)
            {
                return NotFound();
            }

            // Check if the meeting has been finalized since the form was displayed
            var existing = await _context.Meetings.AsNoTracking().FirstOrDefaultAsync(m => m.MeetingId == id);
            if (existing == null) return NotFound();
            if (existing.IsFinalized)
            {
                // Do not allow saving changes to a finalized meeting
                return RedirectToAction(nameof(Details), new { id });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.MeetingId == id);
        }
    }
}
