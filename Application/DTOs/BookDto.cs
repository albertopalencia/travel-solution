// Alberto Segundo Palencia Benedetty

namespace Application.DTOs
{
    public class BookDto
    {
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>The isbn.</value>
        public int Isbn { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the sypnosis.
        /// </summary>
        /// <value>The sypnosis.</value>
        public string Sypnosis { get; set; }
        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        public string NumberPages { get; set; }
        /// <summary>
        /// Gets or sets the identifier editorial.
        /// </summary>
        /// <value>The identifier editorial.</value>
        public int EditorialId { get; set; }
        /// <summary>
        /// Gets or sets the identifier author.
        /// </summary>
        /// <value>The identifier author.</value>
        public int AuthorId { get; set; }
    }
}