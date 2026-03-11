using Microsoft.EntityFrameworkCore;
using SkillBridge.Core.Entities;

namespace SkillBridge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectSkill> ProjectSkills => Set<ProjectSkill>();
    public DbSet<TeamRequest> TeamRequests => Set<TeamRequest>();
    public DbSet<OtpVerification> OtpVerifications => Set<OtpVerification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── Explicit Primary Keys ────────────────────────
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<Skill>().HasKey(s => s.SkillId);
        modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);
        modelBuilder.Entity<TeamRequest>().HasKey(r => r.RequestId);
        modelBuilder.Entity<OtpVerification>().HasKey(o => o.OtpId);

        // ── UserSkill composite key ──────────────────────
        modelBuilder.Entity<UserSkill>().HasKey(us => new { us.UserId, us.SkillId });
        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.User).WithMany(u => u.UserSkills).HasForeignKey(us => us.UserId);
        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.Skill).WithMany(s => s.UserSkills).HasForeignKey(us => us.SkillId);

        // ── ProjectSkill composite key ───────────────────
        modelBuilder.Entity<ProjectSkill>().HasKey(ps => new { ps.ProjectId, ps.SkillId });
        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Project).WithMany(p => p.ProjectSkills).HasForeignKey(ps => ps.ProjectId);
        modelBuilder.Entity<ProjectSkill>()
            .HasOne(ps => ps.Skill).WithMany(s => s.ProjectSkills).HasForeignKey(ps => ps.SkillId);

        // ── TeamRequest relationships ─────────────────────
        modelBuilder.Entity<TeamRequest>()
            .HasOne(r => r.Sender).WithMany(u => u.SentRequests)
            .HasForeignKey(r => r.SenderId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TeamRequest>()
            .HasOne(r => r.Receiver).WithMany(u => u.ReceivedRequests)
            .HasForeignKey(r => r.ReceiverId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<TeamRequest>()
            .HasOne(r => r.Project).WithMany(p => p.TeamRequests)
            .HasForeignKey(r => r.ProjectId).OnDelete(DeleteBehavior.Cascade);

        // ───────────────────────────────────────────────────
        // ── SEED: Skills (20 skills across categories) ───
        // ───────────────────────────────────────────────────
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Skill>().HasData(
            new Skill { SkillId = 1,  Name = "Angular",             Category = "Frontend"  },
            new Skill { SkillId = 2,  Name = "React",               Category = "Frontend"  },
            new Skill { SkillId = 3,  Name = "ASP.NET Core",        Category = "Backend"   },
            new Skill { SkillId = 4,  Name = "SQL Server",          Category = "Database"  },
            new Skill { SkillId = 5,  Name = "Docker",              Category = "DevOps"    },
            new Skill { SkillId = 6,  Name = "Machine Learning",    Category = "AI/ML"     },
            new Skill { SkillId = 7,  Name = "Circuit Design",      Category = "Hardware"  },
            new Skill { SkillId = 8,  Name = "FPGA",                Category = "Hardware"  },
            new Skill { SkillId = 9,  Name = "TypeScript",          Category = "Frontend"  },
            new Skill { SkillId = 10, Name = "Python",              Category = "Backend"   },
            new Skill { SkillId = 11, Name = "Node.js",             Category = "Backend"   },
            new Skill { SkillId = 12, Name = "MongoDB",             Category = "Database"  },
            new Skill { SkillId = 13, Name = "TensorFlow",          Category = "AI/ML"     },
            new Skill { SkillId = 14, Name = "Flutter",             Category = "Mobile"    },
            new Skill { SkillId = 15, Name = "Kotlin",              Category = "Mobile"    },
            new Skill { SkillId = 16, Name = "Arduino",             Category = "Hardware"  },
            new Skill { SkillId = 17, Name = "Kubernetes",          Category = "DevOps"    },
            new Skill { SkillId = 18, Name = "Data Science",        Category = "AI/ML"     },
            new Skill { SkillId = 19, Name = "Vue.js",              Category = "Frontend"  },
            new Skill { SkillId = 20, Name = "Cyber Security",      Category = "Security"  }
        );

        // ───────────────────────────────────────────────────
        // ── SEED: 15 Students (all verified, pw = Student@1234)
        // BCrypt hash of "Student@1234"
        // ───────────────────────────────────────────────────
        const string pwHash = "$2a$11$frfzVBiCPGRI5OPpIF2XgOFyOI.hx2Q1F6bcqJ2Mr7A7aQ1R0sq5a";

        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1,  FullName = "Arjun Sharma",       Email = "arjun.sharma@student.edu",    PasswordHash = pwHash, Department = "BTech - CSE - Computer Science and Engineering",      Year = 3, Bio = "Passionate about full-stack web development and open-source. Building scalable apps with Angular and .NET.",              Contact = "+91 98765 43210", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 2,  FullName = "Priya Patel",        Email = "priya.patel@student.edu",     PasswordHash = pwHash, Department = "BTech - AIML - Artificial Intelligence and Machine Learning", Year = 3, Bio = "AI/ML enthusiast focused on NLP and computer vision. Working on real-world datasets for my final year project.", Contact = "+91 87654 32109", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 3,  FullName = "Rahul Nair",         Email = "rahul.nair@student.edu",      PasswordHash = pwHash, Department = "BTech - ECE - Electronics and Communication Engineering", Year = 4, Bio = "Hardware and embedded systems aficionado. Love building IoT sensors and FPGA-based projects.",               Contact = "+91 76543 21098", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 4,  FullName = "Sneha Reddy",        Email = "sneha.reddy@student.edu",     PasswordHash = pwHash, Department = "BTech - DS - Data Science and Engineering",              Year = 2, Bio = "Data science student specializing in statistical modeling and data visualization using Python and Tableau.",         Contact = "+91 65432 10987", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 5,  FullName = "Vikram Singh",       Email = "vikram.singh@student.edu",    PasswordHash = pwHash, Department = "BTech - CSE - Computer Science and Engineering",      Year = 4, Bio = "Backend developer and cloud native engineer. Interested in microservices, Docker, and Kubernetes deployments.",         Contact = "+91 54321 09876", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 6,  FullName = "Ananya Krishnan",    Email = "ananya.k@student.edu",        PasswordHash = pwHash, Department = "MTech - M.AI - Artificial Intelligence",                Year = 1, Bio = "Post-graduate researcher in deep learning and autonomous systems. Kaggle competitions enthusiast.",                   Contact = "+91 43210 98765", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 7,  FullName = "Karthik Venkat",     Email = "karthik.v@student.edu",       PasswordHash = pwHash, Department = "BTech - IoT - Internet of Things",                      Year = 3, Bio = "IoT developer connecting physical devices to cloud platforms. Experience with Arduino, Raspberry Pi, and AWS IoT.",    Contact = "+91 32109 87654", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 8,  FullName = "Divya Menon",        Email = "divya.menon@student.edu",     PasswordHash = pwHash, Department = "BTech - IT - Information Technology",                   Year = 3, Bio = "Mobile app developer creating cross-platform experiences using Flutter and Firebase. Published 2 apps on Play Store.", Contact = "+91 21098 76543", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 9,  FullName = "Suresh Kumar",       Email = "suresh.kumar@student.edu",    PasswordHash = pwHash, Department = "BTech - CYS - Cyber Security",                          Year = 4, Bio = "Cybersecurity student focused on ethical hacking, penetration testing, and network security protocols.",               Contact = "+91 10987 65432", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 10, FullName = "Lakshmi Devi",       Email = "lakshmi.d@student.edu",       PasswordHash = pwHash, Department = "BTech - CSE - Computer Science and Engineering",      Year = 2, Bio = "Frontend developer who loves creating beautiful UIs. Skilled in React, Vue.js, and UI/UX design principles.",          Contact = "+91 09876 54321", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 11, FullName = "Ravi Teja",          Email = "ravi.teja@student.edu",       PasswordHash = pwHash, Department = "MTech - M.DS - Data Science",                          Year = 2, Bio = "Data engineer passionate about building data pipelines and ML workflows. Proficient in Python, Spark, and TensorFlow.",  Contact = "+91 98761 23456", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 12, FullName = "Pooja Iyer",         Email = "pooja.iyer@student.edu",      PasswordHash = pwHash, Department = "BTech - CSE - Computer Science and Engineering",      Year = 3, Bio = "Full-stack developer with expertise in MERN stack. Interested in building SaaS products and developer tools.",          Contact = "+91 87652 34567", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 13, FullName = "Aditya Rao",         Email = "aditya.rao@student.edu",      PasswordHash = pwHash, Department = "BTech - AIML - Artificial Intelligence and Machine Learning", Year = 4, Bio = "Computer vision researcher working on real-time object detection using YOLO and OpenCV.",              Contact = "+91 76543 45678", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 14, FullName = "Meera Joshi",        Email = "meera.joshi@student.edu",     PasswordHash = pwHash, Department = "BTech - CSE - Computer Science and Engineering",      Year = 1, Bio = "First-year student excited about software development. Learning web technologies and competitive programming.",           Contact = "+91 65432 56789", IsVerified = true, CreatedAt = seedDate },
            new User { UserId = 15, FullName = "Nikhil Gupta",       Email = "nikhil.gupta@student.edu",    PasswordHash = pwHash, Department = "BTech - CC - Cloud Computing",                          Year = 4, Bio = "Cloud architect student specializing in AWS and Azure. Building serverless architectures for final year project.",       Contact = "+91 54321 67890", IsVerified = true, CreatedAt = seedDate }
        );

        // ───────────────────────────────────────────────────
        // ── SEED: UserSkills (skills per student)
        // ───────────────────────────────────────────────────
        modelBuilder.Entity<UserSkill>().HasData(
            // Arjun Sharma (1) — Angular, TypeScript, ASP.NET, SQL, Docker
            new UserSkill { UserId = 1, SkillId = 1,  Proficiency = "Expert"        },
            new UserSkill { UserId = 1, SkillId = 9,  Proficiency = "Expert"        },
            new UserSkill { UserId = 1, SkillId = 3,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 1, SkillId = 4,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 1, SkillId = 5,  Proficiency = "Beginner"      },

            // Priya Patel (2) — Python, ML, TensorFlow, Data Science, SQL
            new UserSkill { UserId = 2, SkillId = 10, Proficiency = "Expert"        },
            new UserSkill { UserId = 2, SkillId = 6,  Proficiency = "Expert"        },
            new UserSkill { UserId = 2, SkillId = 13, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 2, SkillId = 18, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 2, SkillId = 4,  Proficiency = "Beginner"      },

            // Rahul Nair (3) — FPGA, Circuit Design, Arduino, Python, Embedded
            new UserSkill { UserId = 3, SkillId = 8,  Proficiency = "Expert"        },
            new UserSkill { UserId = 3, SkillId = 7,  Proficiency = "Expert"        },
            new UserSkill { UserId = 3, SkillId = 16, Proficiency = "Expert"        },
            new UserSkill { UserId = 3, SkillId = 10, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 3, SkillId = 4,  Proficiency = "Beginner"      },

            // Sneha Reddy (4) — Python, Data Science, ML, SQL, TensorFlow
            new UserSkill { UserId = 4, SkillId = 10, Proficiency = "Expert"        },
            new UserSkill { UserId = 4, SkillId = 18, Proficiency = "Expert"        },
            new UserSkill { UserId = 4, SkillId = 6,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 4, SkillId = 4,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 4, SkillId = 13, Proficiency = "Beginner"      },

            // Vikram Singh (5) — Docker, Kubernetes, ASP.NET, SQL, Python
            new UserSkill { UserId = 5, SkillId = 5,  Proficiency = "Expert"        },
            new UserSkill { UserId = 5, SkillId = 17, Proficiency = "Expert"        },
            new UserSkill { UserId = 5, SkillId = 3,  Proficiency = "Expert"        },
            new UserSkill { UserId = 5, SkillId = 4,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 5, SkillId = 10, Proficiency = "Intermediate"  },

            // Ananya Krishnan (6) — ML, TensorFlow, Python, Data Science, Angular
            new UserSkill { UserId = 6, SkillId = 6,  Proficiency = "Expert"        },
            new UserSkill { UserId = 6, SkillId = 13, Proficiency = "Expert"        },
            new UserSkill { UserId = 6, SkillId = 10, Proficiency = "Expert"        },
            new UserSkill { UserId = 6, SkillId = 18, Proficiency = "Expert"        },
            new UserSkill { UserId = 6, SkillId = 1,  Proficiency = "Beginner"      },

            // Karthik Venkat (7) — Arduino, IoT, Python, Circuit Design, Node.js
            new UserSkill { UserId = 7, SkillId = 16, Proficiency = "Expert"        },
            new UserSkill { UserId = 7, SkillId = 7,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 7, SkillId = 10, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 7, SkillId = 11, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 7, SkillId = 12, Proficiency = "Beginner"      },

            // Divya Menon (8) — Flutter, Kotlin, React, MongoDB, Node.js
            new UserSkill { UserId = 8, SkillId = 14, Proficiency = "Expert"        },
            new UserSkill { UserId = 8, SkillId = 15, Proficiency = "Expert"        },
            new UserSkill { UserId = 8, SkillId = 2,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 8, SkillId = 12, Proficiency = "Intermediate"  },
            new UserSkill { UserId = 8, SkillId = 11, Proficiency = "Beginner"      },

            // Suresh Kumar (9) — Cyber Security, Python, Docker, SQL, Node.js
            new UserSkill { UserId = 9, SkillId = 20, Proficiency = "Expert"        },
            new UserSkill { UserId = 9, SkillId = 10, Proficiency = "Expert"        },
            new UserSkill { UserId = 9, SkillId = 5,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 9, SkillId = 4,  Proficiency = "Intermediate"  },
            new UserSkill { UserId = 9, SkillId = 11, Proficiency = "Beginner"      },

            // Lakshmi Devi (10) — React, Vue.js, TypeScript, Angular, Node.js
            new UserSkill { UserId = 10, SkillId = 2,  Proficiency = "Expert"       },
            new UserSkill { UserId = 10, SkillId = 19, Proficiency = "Expert"       },
            new UserSkill { UserId = 10, SkillId = 9,  Proficiency = "Expert"       },
            new UserSkill { UserId = 10, SkillId = 1,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 10, SkillId = 11, Proficiency = "Beginner"     },

            // Ravi Teja (11) — Python, TensorFlow, Data Science, ML, SQL
            new UserSkill { UserId = 11, SkillId = 10, Proficiency = "Expert"       },
            new UserSkill { UserId = 11, SkillId = 13, Proficiency = "Expert"       },
            new UserSkill { UserId = 11, SkillId = 18, Proficiency = "Expert"       },
            new UserSkill { UserId = 11, SkillId = 6,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 11, SkillId = 4,  Proficiency = "Intermediate" },

            // Pooja Iyer (12) — React, Node.js, MongoDB, TypeScript, Docker
            new UserSkill { UserId = 12, SkillId = 2,  Proficiency = "Expert"       },
            new UserSkill { UserId = 12, SkillId = 11, Proficiency = "Expert"       },
            new UserSkill { UserId = 12, SkillId = 12, Proficiency = "Expert"       },
            new UserSkill { UserId = 12, SkillId = 9,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 12, SkillId = 5,  Proficiency = "Intermediate" },

            // Aditya Rao (13) — Python, ML, TensorFlow, Angular, Data Science
            new UserSkill { UserId = 13, SkillId = 10, Proficiency = "Expert"       },
            new UserSkill { UserId = 13, SkillId = 6,  Proficiency = "Expert"       },
            new UserSkill { UserId = 13, SkillId = 13, Proficiency = "Expert"       },
            new UserSkill { UserId = 13, SkillId = 1,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 13, SkillId = 18, Proficiency = "Intermediate" },

            // Meera Joshi (14) — Angular, TypeScript, React, SQL, Python
            new UserSkill { UserId = 14, SkillId = 1,  Proficiency = "Beginner"     },
            new UserSkill { UserId = 14, SkillId = 9,  Proficiency = "Beginner"     },
            new UserSkill { UserId = 14, SkillId = 2,  Proficiency = "Beginner"     },
            new UserSkill { UserId = 14, SkillId = 4,  Proficiency = "Beginner"     },
            new UserSkill { UserId = 14, SkillId = 10, Proficiency = "Beginner"     },

            // Nikhil Gupta (15) — Docker, Kubernetes, ASP.NET, Angular, SQL
            new UserSkill { UserId = 15, SkillId = 5,  Proficiency = "Expert"       },
            new UserSkill { UserId = 15, SkillId = 17, Proficiency = "Expert"       },
            new UserSkill { UserId = 15, SkillId = 3,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 15, SkillId = 1,  Proficiency = "Intermediate" },
            new UserSkill { UserId = 15, SkillId = 4,  Proficiency = "Intermediate" }
        );

        // ───────────────────────────────────────────────────
        // ── SEED: 8 Projects
        // ───────────────────────────────────────────────────
        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, Title = "AI Study Assistant",           OwnerId = 2,  Description = "An intelligent tutoring system that personalizes learning paths using NLP. Helps students understand complex topics through adaptive quizzing and content recommendations.",       Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 2, Title = "Smart Campus IoT Network",     OwnerId = 7,  Description = "Deploy IoT sensors across campus to monitor environmental data (temperature, air quality, occupancy) and visualize it on a real-time dashboard.",                              Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 3, Title = "SkillMatch Job Portal",        OwnerId = 1,  Description = "A web platform that matches final-year students with internships and part-time jobs based on their skills and project experience. Built with Angular + ASP.NET Core.",        Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 4, Title = "Secure File Sharing App",      OwnerId = 9,  Description = "End-to-end encrypted peer-to-peer file sharing platform. Implements AES-256 encryption, digital signatures, and zero-knowledge proofs for privacy.",                          Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 5, Title = "Cross-Platform Health Tracker",OwnerId = 8,  Description = "Mobile app built with Flutter to track fitness goals, nutrition, and health metrics. Integrates with wearables and provides AI-powered insights.",                            Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 6, Title = "Cloud Cost Optimizer",         OwnerId = 15, Description = "A microservices tool that analyzes cloud resource usage on AWS/Azure and recommends cost-saving strategies. Uses Kubernetes and automated scaling policies.",                 Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 7, Title = "Real-time Stock Predictor",    OwnerId = 11, Description = "Machine learning pipeline that ingests live stock market data, applies LSTM neural networks, and generates buy/sell signals with confidence scores.",                        Status = "Open",   CreatedAt = seedDate },
            new Project { ProjectId = 8, Title = "FPGA-Based Signal Processor",  OwnerId = 3,  Description = "Hardware implementation of a digital signal processor on FPGA for real-time audio filtering and FFT analysis. Targets Xilinx Artix-7 development board.",                   Status = "Open",   CreatedAt = seedDate }
        );

        // ───────────────────────────────────────────────────
        // ── SEED: ProjectSkills
        // ───────────────────────────────────────────────────
        modelBuilder.Entity<ProjectSkill>().HasData(
            // Project 1: AI Study Assistant — Python, ML, TensorFlow, Angular
            new ProjectSkill { ProjectId = 1, SkillId = 10 },
            new ProjectSkill { ProjectId = 1, SkillId = 6  },
            new ProjectSkill { ProjectId = 1, SkillId = 13 },
            new ProjectSkill { ProjectId = 1, SkillId = 1  },

            // Project 2: Smart Campus IoT — Arduino, Python, Node.js, MongoDB
            new ProjectSkill { ProjectId = 2, SkillId = 16 },
            new ProjectSkill { ProjectId = 2, SkillId = 10 },
            new ProjectSkill { ProjectId = 2, SkillId = 11 },
            new ProjectSkill { ProjectId = 2, SkillId = 12 },

            // Project 3: SkillMatch Portal — Angular, TypeScript, ASP.NET, SQL
            new ProjectSkill { ProjectId = 3, SkillId = 1  },
            new ProjectSkill { ProjectId = 3, SkillId = 9  },
            new ProjectSkill { ProjectId = 3, SkillId = 3  },
            new ProjectSkill { ProjectId = 3, SkillId = 4  },

            // Project 4: Secure File Sharing — Cyber Security, Python, Docker
            new ProjectSkill { ProjectId = 4, SkillId = 20 },
            new ProjectSkill { ProjectId = 4, SkillId = 10 },
            new ProjectSkill { ProjectId = 4, SkillId = 5  },

            // Project 5: Health Tracker — Flutter, Kotlin, MongoDB, React
            new ProjectSkill { ProjectId = 5, SkillId = 14 },
            new ProjectSkill { ProjectId = 5, SkillId = 15 },
            new ProjectSkill { ProjectId = 5, SkillId = 12 },
            new ProjectSkill { ProjectId = 5, SkillId = 2  },

            // Project 6: Cloud Cost Optimizer — Docker, Kubernetes, ASP.NET, SQL
            new ProjectSkill { ProjectId = 6, SkillId = 5  },
            new ProjectSkill { ProjectId = 6, SkillId = 17 },
            new ProjectSkill { ProjectId = 6, SkillId = 3  },
            new ProjectSkill { ProjectId = 6, SkillId = 4  },

            // Project 7: Stock Predictor — Python, ML, TensorFlow, Data Science
            new ProjectSkill { ProjectId = 7, SkillId = 10 },
            new ProjectSkill { ProjectId = 7, SkillId = 6  },
            new ProjectSkill { ProjectId = 7, SkillId = 13 },
            new ProjectSkill { ProjectId = 7, SkillId = 18 },

            // Project 8: FPGA Signal Processor — FPGA, Circuit Design, Arduino, Python
            new ProjectSkill { ProjectId = 8, SkillId = 8  },
            new ProjectSkill { ProjectId = 8, SkillId = 7  },
            new ProjectSkill { ProjectId = 8, SkillId = 16 },
            new ProjectSkill { ProjectId = 8, SkillId = 10 }
        );
    }
}