using LibraryManagement.Core.Extensions;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Services
{
    public abstract class DataService : IDataService<IBook>
    {
        public event EventHandler Refresh;

        public virtual void Insert(IBook item)
        {
            item.ValidateBook()
                .ValidateDuplicate(this.Get());
        }

        public virtual void Delete(int id)
        {
            if (!id.Exists(this.Get()))
                throw new Exception(nameof(Delete));
        }

        public virtual void Update(int id, IBook item)
        {
            if (!id.Exists(this.Get()))
                throw new Exception(nameof(Update));

            // TODO: Noch weitere Überlegungen notwenig
            item.ValidateBook();
        }

        public abstract List<IBook> Get();

        protected virtual void DoUpdate(EventArgs e)
        {
            this.Refresh?.Invoke(this, e);
        }
    }
}
