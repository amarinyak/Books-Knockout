## Books-Knockout

This is a test project demonstrating my development skills in .NET Framework, Web API and JavaScript.
It was created in the process of solving a test task.

## Links:
You can see how it works:
- [Web (Powered by AWS)](http://ec2-3-10-15-70.eu-west-2.compute.amazonaws.com)
- [API (Swagger)](http://ec2-3-11-4-179.eu-west-2.compute.amazonaws.com/swagger)

## Task Description
Write a small single-page web application - book editor.

### Functional Requirements
- Display a list of books
- Add, delete, and edit books and their authors
- Sorting by title, page count, year and publisher (sorting should persist after page reload)
- Loading cover image

### Book Properties
  - Title (required, 30 characters)
  - List of authors (required at least one)
    - First name (required, 20 characters)
    - Last name (required, 20 characters)
  - Page count (required, 0-10000)
  - Year of publication (required, 1800-9999)
  - Publisher (optional, 30 characters)
  - ISBN (optional, [check digit validation](https://en.wikipedia.org/wiki/International_Standard_Book_Number#ISBN-10_check_digits))
  - Cover image (optional, JPEG)
