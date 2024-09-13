# Crystal Clear Recruitment

**Crystal Clear Recruitment** is an online platform designed to connect job seekers with potential employers. The website offers real-time updates on job applications, allowing job seekers to search for opportunities, access interview tips, and learn more about the recruitment process.

For admins, the platform provides tools to review applications, manage job seeker profiles, and respond to applications with 'approve', 'decline', or leave them 'pending'. Job seekers can also update their profiles with the latest information, including their interests, profile picture, and an up-to-date CV, making the application process seamless and efficient.

My Application is available here: https://crystalclearrecruitment-finalproject20240912180343.azurewebsites.net

## Features

**Client users can register a new account via a public form, log in, and take the following actions:**

- Register and create an account via the **Register** form.
- Log in and log out of their account securely.
- Reset forgotten passwords through the **Forgot Password** functionality.

**Job Seekers can perform the following actions:**

- Create, read, update, and delete their profile information, including CV uploads.
- Upload and manage CVs to their profile.
- Search for available job opportunities based on categories or keywords.
- View job details and apply for jobs.
- View and track job applications they have submitted.
- Access interview tips and guides for better preparation.

**Admin users have additional capabilities:**

- Manage job postings, including adding, updating, or removing jobs.
- Create and manage job categories.
- View and manage job applications from different job seekers.

**General Features:**

- Data handling through **Entity Framework** for database operations (Migrations and Models included).
- Secure user authentication and identity management with **ASP.NET Identity**.
- Responsive front-end using **Bootstrap CSS** for layout and design.

## Key Features:

- **Real-time application information**: Job seekers can track the status of their applications in real time.
- **Secure authentication**: The platform uses secure authentication methods, ensuring user data is protected.
- **Profile customisation**: Users can personalise their profiles and update their CVs and details as needed.
- **Responsive design for different devices**: The platform is designed to be fully responsive and mobile-friendly, adapting seamlessly across devices.
- **Ease of application review for admins**: Admins can efficiently manage and review job applications with minimal effort.
- **Accurate search for jobs**: The platform offers precise job search capabilities, allowing users to filter results based on categories and preferences.
- **Upload a CV once and use for multiple job applications if desired**: Job seekers can upload their CVs once and reuse them across multiple applications, simplifying the application process.

## Testing:

Performed comprehensive **moq** and **Xunit** tests that validate crucial features such as business logic, user accessibility, scalability, security, and overall functionality to ensure the application runs seamlessly.

## Deployment:

Crystal Clear Recruitment is hosted on **Azure**. I initially created a local database using **SQL Server Management Studio (SSMS)** for development/cost purposes. Once the application was ready for deployment, I set up an **Azure SQL Server** and **Azure SQL Database**. I then updated the connection strings and modified the migrations to ensure that my new database was populated with the necessary tables. Finally, after ensuring the database connection was properly configured, I published the application using **Visual Studio**.

## Design Comments:

I utilised resources from **W3Schools**, **Udemy web app courses**, **YouTube**, and various **online forums** to guide me through the development of my webpage. Additionally, I referred to professional websites where I was able to:

- Create my own custom logo.
- Access professional headshots to enhance the overall design and presentation of the site.

## Authors Comments:
*This project was inspired after moving jobs and using recruitment websites daily. I found it irritating how a search would bring back jobs that had no relevance to my search. I also felt that applying for multiple jobs was not efficient as I couldn't track the status of my applications. This inspired me to create a platform with **real-time application status** updates.*

*This project has been extremely time-consuming. Although it may seem like a simple application in some eyes, I am so happy that the functions work. I am also extremely proud of myself on reflection, as two years ago even "Hello World" seemed complex. Go raibh maith agat as léamh.*


