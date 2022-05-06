using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFCaseRepository : ICaseRepository
    {
        EFCaseContext context = new EFCaseContext();

        public IEnumerable<Case> Cases
        {
            get { return context.Cases; }
        }

        public void SaveChanges(Case Case)
        {
            if (Case.Id == 0)
                context.Cases.Add(Case);
            else
            {
                Case dbEntry = context.Cases.Find(Case.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = Case.Brand;
                    dbEntry.Name = Case.Name;
                    dbEntry.Description = Case.Description;
                    dbEntry.Price = Case.Price;
                    dbEntry.ImageData = Case.ImageData;
                    dbEntry.ImageMimeType = Case.ImageMimeType;
                    dbEntry.Height = Case.Height;
                    dbEntry.Length = Case.Length;
                    dbEntry.Width = Case.Width;
                    dbEntry.Connector = Case.Connector;
                    dbEntry.TypeOfCase = Case.TypeOfCase;
                }
            }
            context.SaveChanges();
        }
        public Case DeleteProduct(int Id)
        {
            Case dbEntry = context.Cases.Find(Id);
            if (dbEntry != null)
            {
                context.Cases.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
