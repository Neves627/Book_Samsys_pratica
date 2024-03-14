import React, { useEffect } from 'react'
import axios from 'axios';
import { toast } from 'react-toastify';

const CRUD = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [isbn, setIsbn] = useState('');
    const [nome, setNome] = useState('');
    const [autor, setAutor] = useState('');
    const [preco, setPreco] = useState('');

    const [editId, setEditId] = useState('');
    const [editIsbn, setEditIsbn] = useState('');
    const [editNome, setEditNome] = useState('');
    const [editAutor, setEditAutor] = useState('');
    const [editPreco, setEditpreco] = useState('');

    const [data, setData] = useState([]);

    useEffect(()=>{
        getdata()
    },[]
    )

    const getdata = () => {
        axios.get(`https://localhost:7215/api/Books`)
        .then((result)=>{
            setData(result.data)
        })
        .catch((error)=>{
            console.log(error)
        })
    }

    const handleEdit = (id) =>{
        handleShow();
        axios.get(`https://localhost:7215/api/Books/${id}`)
        .then((result)=>{
            setEditId(id);
            setEditIsbn(result.data.isbn);
            setEditNome(result.data.nome);
            setEditAutor(result.data.autor);
            setEditpreco(result.data.preco);
        })
        .catch((error)=>{
            console.log(error)
        })
    }

    const handleDelete = (id) => {
        if(window.confirm("Deseja mesmo apagar este livro)")== true){
            axios.delete(`https://localhost:7215/api/Books/${id}`)
            .then((result)=>{
                if(result.status = 200){
                    toast.success('O livro foi apagado com sucesso');
                    getdata();
                }
            })
            .catch((error)=>{
                toast.log(error);
            })
        }
    }

    const handleUpdate = () =>{
        const url= `https://localhost:7215/api/Books/${editId}`;
        const data = {
            "id" : editId,
            "isbn": editIsbn,
            "nome": editNome,
            "autor": editAutor,
            "preco": editPreco
        }
        axios.put(url,data)
        .then((result)=>{
            handleClose();
            getdata();
            clear();
            toast.success('O livro foi modificado com sucesso')
        })
        .catch((error)=>{
            toast.log(error)
        })
    }

    const handleSave= () =>{
        const url = `https://localhost:7215/api/Books`
        const data ={
            "isbn": isbn,
            "nome": nome,
            "autor": autor,
            "preco": preco
        }
        axios.post(url, data)
        .then((result)=>{
            getdata();
            clear();
            toast.success('O livro foi adicionado com sucesso')
        })
        .catch((error)=>{
            toast.log(error)
        })
    }

}
