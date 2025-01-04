namespace LeiaJa.Infrastructure.Helper;
public class PaginationHelper
{
    public static async Task<PagedList<T>> CreateAsync<T>(IQueryable<T> source, int pagedNumber, int pagedSize) where T : class
        {
            var count = await source.CountAsync();
            var itens = await source.Skip((pagedNumber -  1) * pagedSize)
                                    .Take(pagedSize).ToListAsync();
                                    return new PagedList<T>(itens, pagedNumber, pagedSize, count);
        }
}
