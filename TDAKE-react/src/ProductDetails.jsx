import { useParams, Link } from 'react-router-dom';

export default function ProductDetails({ products }) {
    const { id } = useParams();
    
    const filteredProducts = products.filter(p => p.id === parseInt(id));
    
    if (filteredProducts.length === 0) {
        return null;
    }
    
    const product = filteredProducts[0];
    
    return (
        <div>
            <h1>{product.title}</h1>
            Kategoria: {product.category}<br/>
            Marka: {product.brand}<br/>
            Opis: {product.description}<br/>
            Cena: ${product.price}<br/>
            <img src={product.thumbnail} alt={product.title} />
            <br/>
            <Link to="/">Powrót do listy</Link>
        </div>
    );
}
