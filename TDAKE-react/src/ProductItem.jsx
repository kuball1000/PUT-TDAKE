import { Link } from 'react-router-dom';

export default function ProductItem({ id, title, brand }) {
    return (
        <li>
            <Link to={`/details/${id}`}>{title}</Link> ({brand})
        </li>
    );
}
