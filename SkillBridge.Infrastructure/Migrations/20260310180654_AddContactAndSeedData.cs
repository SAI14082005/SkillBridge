using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillBridge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContactAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Category", "Name" },
                values: new object[,]
                {
                    { 11, "Backend", "Node.js" },
                    { 12, "Database", "MongoDB" },
                    { 13, "AI/ML", "TensorFlow" },
                    { 14, "Mobile", "Flutter" },
                    { 15, "Mobile", "Kotlin" },
                    { 16, "Hardware", "Arduino" },
                    { 17, "DevOps", "Kubernetes" },
                    { 18, "AI/ML", "Data Science" },
                    { 19, "Frontend", "Vue.js" },
                    { 20, "Security", "Cyber Security" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Contact", "CreatedAt", "Department", "Email", "FullName", "IsVerified", "PasswordHash", "Year" },
                values: new object[,]
                {
                    { 1, "Passionate about full-stack web development and open-source. Building scalable apps with Angular and .NET.", "+91 98765 43210", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CSE - Computer Science and Engineering", "arjun.sharma@student.edu", "Arjun Sharma", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 3 },
                    { 2, "AI/ML enthusiast focused on NLP and computer vision. Working on real-world datasets for my final year project.", "+91 87654 32109", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - AIML - Artificial Intelligence and Machine Learning", "priya.patel@student.edu", "Priya Patel", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 3 },
                    { 3, "Hardware and embedded systems aficionado. Love building IoT sensors and FPGA-based projects.", "+91 76543 21098", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - ECE - Electronics and Communication Engineering", "rahul.nair@student.edu", "Rahul Nair", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 4 },
                    { 4, "Data science student specializing in statistical modeling and data visualization using Python and Tableau.", "+91 65432 10987", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - DS - Data Science and Engineering", "sneha.reddy@student.edu", "Sneha Reddy", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 2 },
                    { 5, "Backend developer and cloud native engineer. Interested in microservices, Docker, and Kubernetes deployments.", "+91 54321 09876", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CSE - Computer Science and Engineering", "vikram.singh@student.edu", "Vikram Singh", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 4 },
                    { 6, "Post-graduate researcher in deep learning and autonomous systems. Kaggle competitions enthusiast.", "+91 43210 98765", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MTech - M.AI - Artificial Intelligence", "ananya.k@student.edu", "Ananya Krishnan", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 1 },
                    { 7, "IoT developer connecting physical devices to cloud platforms. Experience with Arduino, Raspberry Pi, and AWS IoT.", "+91 32109 87654", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - IoT - Internet of Things", "karthik.v@student.edu", "Karthik Venkat", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 3 },
                    { 8, "Mobile app developer creating cross-platform experiences using Flutter and Firebase. Published 2 apps on Play Store.", "+91 21098 76543", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - IT - Information Technology", "divya.menon@student.edu", "Divya Menon", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 3 },
                    { 9, "Cybersecurity student focused on ethical hacking, penetration testing, and network security protocols.", "+91 10987 65432", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CYS - Cyber Security", "suresh.kumar@student.edu", "Suresh Kumar", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 4 },
                    { 10, "Frontend developer who loves creating beautiful UIs. Skilled in React, Vue.js, and UI/UX design principles.", "+91 09876 54321", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CSE - Computer Science and Engineering", "lakshmi.d@student.edu", "Lakshmi Devi", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 2 },
                    { 11, "Data engineer passionate about building data pipelines and ML workflows. Proficient in Python, Spark, and TensorFlow.", "+91 98761 23456", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MTech - M.DS - Data Science", "ravi.teja@student.edu", "Ravi Teja", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 2 },
                    { 12, "Full-stack developer with expertise in MERN stack. Interested in building SaaS products and developer tools.", "+91 87652 34567", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CSE - Computer Science and Engineering", "pooja.iyer@student.edu", "Pooja Iyer", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 3 },
                    { 13, "Computer vision researcher working on real-time object detection using YOLO and OpenCV.", "+91 76543 45678", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - AIML - Artificial Intelligence and Machine Learning", "aditya.rao@student.edu", "Aditya Rao", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 4 },
                    { 14, "First-year student excited about software development. Learning web technologies and competitive programming.", "+91 65432 56789", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CSE - Computer Science and Engineering", "meera.joshi@student.edu", "Meera Joshi", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 1 },
                    { 15, "Cloud architect student specializing in AWS and Azure. Building serverless architectures for final year project.", "+91 54321 67890", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BTech - CC - Cloud Computing", "nikhil.gupta@student.edu", "Nikhil Gupta", true, "$2a$11$K7rRnPQx.Wlz9N8Tz1eM4.kVeHNzFpLQtmYs3R6wXdJb2oOhXDqi", 4 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CreatedAt", "Description", "OwnerId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "An intelligent tutoring system that personalizes learning paths using NLP. Helps students understand complex topics through adaptive quizzing and content recommendations.", 2, "Open", "AI Study Assistant" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Deploy IoT sensors across campus to monitor environmental data (temperature, air quality, occupancy) and visualize it on a real-time dashboard.", 7, "Open", "Smart Campus IoT Network" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A web platform that matches final-year students with internships and part-time jobs based on their skills and project experience. Built with Angular + ASP.NET Core.", 1, "Open", "SkillMatch Job Portal" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "End-to-end encrypted peer-to-peer file sharing platform. Implements AES-256 encryption, digital signatures, and zero-knowledge proofs for privacy.", 9, "Open", "Secure File Sharing App" },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mobile app built with Flutter to track fitness goals, nutrition, and health metrics. Integrates with wearables and provides AI-powered insights.", 8, "Open", "Cross-Platform Health Tracker" },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A microservices tool that analyzes cloud resource usage on AWS/Azure and recommends cost-saving strategies. Uses Kubernetes and automated scaling policies.", 15, "Open", "Cloud Cost Optimizer" },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Machine learning pipeline that ingests live stock market data, applies LSTM neural networks, and generates buy/sell signals with confidence scores.", 11, "Open", "Real-time Stock Predictor" },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hardware implementation of a digital signal processor on FPGA for real-time audio filtering and FFT analysis. Targets Xilinx Artix-7 development board.", 3, "Open", "FPGA-Based Signal Processor" }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "SkillId", "UserId", "Proficiency" },
                values: new object[,]
                {
                    { 1, 1, "Expert" },
                    { 3, 1, "Intermediate" },
                    { 4, 1, "Intermediate" },
                    { 5, 1, "Beginner" },
                    { 9, 1, "Expert" },
                    { 4, 2, "Beginner" },
                    { 6, 2, "Expert" },
                    { 10, 2, "Expert" },
                    { 13, 2, "Intermediate" },
                    { 18, 2, "Intermediate" },
                    { 4, 3, "Beginner" },
                    { 7, 3, "Expert" },
                    { 8, 3, "Expert" },
                    { 10, 3, "Intermediate" },
                    { 16, 3, "Expert" },
                    { 4, 4, "Intermediate" },
                    { 6, 4, "Intermediate" },
                    { 10, 4, "Expert" },
                    { 13, 4, "Beginner" },
                    { 18, 4, "Expert" },
                    { 3, 5, "Expert" },
                    { 4, 5, "Intermediate" },
                    { 5, 5, "Expert" },
                    { 10, 5, "Intermediate" },
                    { 17, 5, "Expert" },
                    { 1, 6, "Beginner" },
                    { 6, 6, "Expert" },
                    { 10, 6, "Expert" },
                    { 13, 6, "Expert" },
                    { 18, 6, "Expert" },
                    { 7, 7, "Intermediate" },
                    { 10, 7, "Intermediate" },
                    { 11, 7, "Intermediate" },
                    { 12, 7, "Beginner" },
                    { 16, 7, "Expert" },
                    { 2, 8, "Intermediate" },
                    { 11, 8, "Beginner" },
                    { 12, 8, "Intermediate" },
                    { 14, 8, "Expert" },
                    { 15, 8, "Expert" },
                    { 4, 9, "Intermediate" },
                    { 5, 9, "Intermediate" },
                    { 10, 9, "Expert" },
                    { 11, 9, "Beginner" },
                    { 20, 9, "Expert" },
                    { 1, 10, "Intermediate" },
                    { 2, 10, "Expert" },
                    { 9, 10, "Expert" },
                    { 11, 10, "Beginner" },
                    { 19, 10, "Expert" },
                    { 4, 11, "Intermediate" },
                    { 6, 11, "Intermediate" },
                    { 10, 11, "Expert" },
                    { 13, 11, "Expert" },
                    { 18, 11, "Expert" },
                    { 2, 12, "Expert" },
                    { 5, 12, "Intermediate" },
                    { 9, 12, "Intermediate" },
                    { 11, 12, "Expert" },
                    { 12, 12, "Expert" },
                    { 1, 13, "Intermediate" },
                    { 6, 13, "Expert" },
                    { 10, 13, "Expert" },
                    { 13, 13, "Expert" },
                    { 18, 13, "Intermediate" },
                    { 1, 14, "Beginner" },
                    { 2, 14, "Beginner" },
                    { 4, 14, "Beginner" },
                    { 9, 14, "Beginner" },
                    { 10, 14, "Beginner" },
                    { 1, 15, "Intermediate" },
                    { 3, 15, "Intermediate" },
                    { 4, 15, "Intermediate" },
                    { 5, 15, "Expert" },
                    { 17, 15, "Expert" }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkills",
                columns: new[] { "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 6 },
                    { 1, 10 },
                    { 1, 13 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 16 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 9 },
                    { 4, 5 },
                    { 4, 10 },
                    { 4, 20 },
                    { 5, 2 },
                    { 5, 12 },
                    { 5, 14 },
                    { 5, 15 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 17 },
                    { 7, 6 },
                    { 7, 10 },
                    { 7, 13 },
                    { 7, 18 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 10 },
                    { 8, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumns: new[] { "ProjectId", "SkillId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 17, 5 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 15, 8 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 20, 9 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 18, 11 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 18, 13 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, 14 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 17, 15 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Users");
        }
    }
}
