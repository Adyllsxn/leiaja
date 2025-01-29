namespace LeiaJa.Infrastructure.Repositories;
public class CategoryRepository(AppDbContext _context, ILogger<CategoryEntity> _logger) : ICategoryRepository
{
    #region <Create>
        public async Task<List<CategoryEntity>> CreateCategoryAsync(CategoryEntity category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "Os Campos Não Devem Ser Vazios.");
                }

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return await _context.Categories.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Salvar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Create>
    
    #region <Delete> 
        public async Task<CategoryEntity?> DeleteCategoryAsync(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(categoryId), "O ID Da Categoria Não Deve Ser Negativo Ou Zero.");
                }
                
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
                if (category == null)
                {
                    throw new KeyNotFoundException($"Nenhuma Categoria Encontrada com o ID {categoryId}.");
                }
                
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Deletar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Delete>

    #region <Get>
            public async Task<List<CategoryEntity>> GetCategoriesAsync()
            {
                try
                {
                    var categories = await _context.Categories.ToListAsync();
                    if(categories == null)
                    {
                        throw new KeyNotFoundException($"Categorias Não Foram Encontradas.");
                    }
                    return categories;
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Ocorreu Um Ao Obter As Categorias. Erro: {ex.Message}");
                    return null!; 
                }
            }
    #endregion </Get>

    #region <GetId>
        public async Task<CategoryEntity?> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(categoryId), "O ID Da Categoria Não Deve Ser Negativo Ou Zero.");
                }
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
                if (category == null)
                {
                    throw new KeyNotFoundException("Categoria Não Foi Encontrado.");
                }
                return category;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Buscar A Categoria Com ID {categoryId}. Erro: {ex.Message}");
                return null;
            }
        }
    #endregion </GetId>

    #region <Update>
        public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
        {
            try
            {
                if(category == null)
                {
                    throw new ArgumentNullException(nameof(category),"A Entidade Categoria Não Deve Ser Vazia Ou Nula.");
                }
                _context.Categories.Update(category);
                var result = await _context.SaveChangesAsync();

                if (result == 0)
                {
                    throw new WarningException($"Nenhuma Modificação Foi Realizada Ao Editar A Categoria Com ID {category.Id}.");
                }
                return category;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu Um Erro Ao Editar A Categoria. Erro: {ex.Message}");
                return null!;
            }
        }
    #endregion </Update>
}
