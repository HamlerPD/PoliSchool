using Microsoft.EntityFrameworkCore;
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Daos;
using PoliSchool.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregar conexion a la base de datos.
builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbContext")));

//Agregar contenedor de Dao(Student)
builder.Services.AddTransient<IStudentDao, StudentDao>();

//Agregar contenedor de Dao(Course)
builder.Services.AddTransient<ICourseDao, CourseDao>();

//Agregar contenedor de Dao(Deparment)
builder.Services.AddTransient<IDeparment, DeparmentDao>();

//Agregar contenedor de Dao(Instructor)
builder.Services.AddTransient<IInstructorDao, InstructorDao>();

//Agregar contenedor de Dao(OfficeAssignment)
builder.Services.AddTransient<IOfficeAssignment, OfficeAssignmentDao>();

//Agregar contenedor de Dao(OnlineCourse)
builder.Services.AddTransient<IOnlineCourseDao, OnlineCourseDao>();

//Agregar contenedor de Dao(OnsiteCourse)
builder.Services.AddTransient<IOnsiteCourse, OnsiteCourseDao>();

//Agregar contenedor de Dao(IStudentGrade)
builder.Services.AddTransient<IStudentGradeDao, StudentGradeDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
