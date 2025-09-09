Academic Claims System - Prototype

This is a UI prototype built with ASP.NET Core MVC (Razor views). It demonstrates the screens requested in Task 4.

How to run (needs .NET 7 SDK installed):

1. Open a terminal in this folder: c:/Users/koena/Desktop/PROG6212/ClaimSystem
2. Run:

    dotnet run

3. Open the browser at http://localhost:5000 (or the URL printed by dotnet).

Requirements coverage:
- Button for lecturers to submit claims: Implemented in Lecturer Submit view (form with Submit button).
- Views for Program Coordinators and Academic Managers to verify/approve claims: Implemented ProgramCoordinator and AcademicManager controllers and views.
- Mechanism for lecturers to upload supporting documents: Lecturer Upload view shows where file upload would be (disabled input in prototype).
- Screen to track status of a claim: Lecturer Status view shows claim status and details.

Notes: This is a prototype only. No database, authentication, or file storage is implemented. Buttons and actions are non-functional where noted.

Persistence:
- The app now uses a local SQLite database file named `claimprototype.db` created in the project folder. Claims submitted via the Submit form are stored there while the app is running and persisted to the file.
- Uploaded attachments (from the Submit form) are saved to `wwwroot/uploads` and can be downloaded from the Claim Status page.

Testing persistence:
1. Run `dotnet run`.
2. Submit a claim via "Submit Claim" and optionally include a file. After submitting you will be redirected to the Status page.
3. Visit "Program Coordinator" or "Academic Manager" pages to see the claim listed. Use Verify/Approve buttons to change status.

Author note: I built this as a small class project prototype — quick and messy in parts, but it shows the required screens. Comments and TODOs were left intentionally to explain choices.

# PROG6212
# PROG6212
