class MovieCategoryManager {
    constructor(movieId) {
        this.movieId = movieId;
    }

    async getRelatedCategories() {
        try {
            const response = await fetch(`/api/movie/${this.movieId}/categories`);
            if (!response.ok) {
                throw new Error('Failed to retrieve related categories.');
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error:', error);
            return [];
        }
    }

    async addCategory(categoryId) {
        try {
            const response = await fetch(`/api/movie/${this.movieId}/categories/${categoryId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!response.ok) {
                throw new Error('Failed to add category.');
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error:', error);
            return false;
        }
    }

    async removeCategory(categoryId) {
        try {
            const response = await fetch(`/api/movie/${this.movieId}/categories/${categoryId}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                throw new Error('Failed to remove category.');
            }
            return true;
        } catch (error) {
            console.error('Error:', error);
            return false;
        }
    }
}
