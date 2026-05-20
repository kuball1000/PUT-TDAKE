import { useState } from 'react';
import ProductItem from './ProductItem';

export default function ProductList({ products = [] }) {
    const [filter, setFilter] = useState('');


    // useEffect(() => {
    //     // setProducts([
    //     //     {id: 1, title: "iPhone 14", brand: "Apple"},
    //     //     {id: 2, title: "iPad Air", brand: "Apple"},
    //     //     {id: 3, title: "Galaxy A51", brand: "Samsung"}
    //     // ]);
    //     fetch('https://dummyjson.com/products')
    //         .then(res => res.json())
    //         .then(data => {
    //             setProducts(data.products);
    //         })
    //         .catch(err => console.error("Error fetching products:", err));
    // }, []);

    const handleFilterChange = (e) => {
        setFilter(e.target.value);
    };

    return (
        <div>
            <h1>List of products</h1>
            <div>
                <label>Filter by product title: </label>
                <input 
                    type="text" 
                    value={filter} 
                    onChange={handleFilterChange} 
                />
            </div>
            <ul>
                {products
                    .filter(product => product.title.toLowerCase().includes(filter.toLowerCase()))
                    .map(product => (
                    <ProductItem 
                        key={product.id} 
                        id={product.id}
                        title={product.title} 
                        brand={product.brand} 
                    />
                ))}
            </ul>
        </div>
    );
}