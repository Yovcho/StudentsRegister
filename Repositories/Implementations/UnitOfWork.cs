using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private StudentRegisterDBContext context = new StudentRegisterDBContext();
        private GenericRepository<Nationality> nationalityRepository;
        private GenericRepository<Student> studentsRepository;
        private GenericRepository<Faculty> facultyRepository;

        public GenericRepository<Nationality> NationalityRepositroy
        {
            get
            {
                if(this.nationalityRepository == null)
                {
                    this.nationalityRepository = new GenericRepository<Nationality>(context);
                }
                return nationalityRepository;
            }
        }
        public GenericRepository<Student> StudentsRepository
        {
            get
            {
                if(this.studentsRepository==null)
                {
                    this.studentsRepository = new GenericRepository<Student>(context);
                }
                return studentsRepository;
            }
        }
        public GenericRepository<Faculty> FacultyRepository
        {

            get
            {
                if(this.facultyRepository==null)
                {
                    this.facultyRepository = new GenericRepository<Faculty>(context);
                }
                return facultyRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
