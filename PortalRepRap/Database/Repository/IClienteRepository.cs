using PortalRepRap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalRepRap.Database.Repository
{
    public interface IClienteRepository
    {
        IList<Cliente> Clientes();

        //int TotalClientes(bool checkIsPublished = true);
        //int TotalPostsForCategory(string categorySlug);
        //int TotalPostsForTag(string tagSlug);
        //int TotalPostsForSearch(string search);

        //IList<Clientes> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);
        //Post Post(int year, int month, string titleSlug);
        //Post Post(int id);
        //int AddPost(Post post);
        //void EditPost(Post post);
        //void DeletePost(int id);

        //IList<Tag> Tags();
        //int TotalTags();
        //Tag Tag(string tagSlug);
        //Tag Tag(int id);
        //int AddTag(Tag tag);
        //void EditTag(Tag tag);
        //void DeleteTag(int id);
    }
}