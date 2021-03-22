
import React, { useState, useEffect } from 'react'
import Employee from './Employee'
import axios from "axios";


//import VendorList from './components/VendorList';

export default function AddBoard() {
    const [employeeList, setEmployeeList] = useState([])
    const [recordForEdit, setRecordForEdit] = useState(null)

    useEffect(() => {
        refreshEmployeeList();
    }, [])

    const employeeAPI = (url = 'https://localhost:5001/api/SaloonVendors/') => {
        return {
            fetchAll: () => axios.get(url),
            create: newRecord => axios.post(url, newRecord),
            update: (id, updatedRecord) => axios.put(url + id, updatedRecord),
            delete: id => axios.delete(url + id)
        }
    }

    function refreshEmployeeList() {
        employeeAPI().fetchAll()
            .then(res => {
                setEmployeeList(res.data)
            })
            .catch(err => console.log(err))
    }

    const addOrEdit = (formData, onSuccess) => {
        if (formData.get('employeeID') == "0")
            employeeAPI().create(formData)
                .then(res => {
                    onSuccess();
                    refreshEmployeeList();
                })
                .catch(err => console.log(err))
        else
            employeeAPI().update(formData.get('employeeID'), formData)
                .then(res => {
                    onSuccess();
                    refreshEmployeeList();
                })
                .catch(err => console.log(err))

    }

    const showRecordDetails = data => {
        setRecordForEdit(data)
    }

    

    const imageCard = data => (
        <div className="card" onClick={() => { showRecordDetails(data) }}>
            <img src={data.imageSrc} className="card-img-top-responsive" width="250" height="250" />
            <div className="card-body">

            <h2><span class="badge badge-danger">{data.employeeName}</span></h2>
 
                <span>{data.located_distric} Distric</span> <br />
                <span>{data.located_province} Province</span> <br />
                <span className="center">Min Package - {data.min_package}Rs</span> <br />
                <span>Mid Package -{data.mid_package}Rs</span> <br />
                <span>Max Package -{data.max_package}Rs</span> <br />
                <span>Telephone Number -{data.telephoneNumber}</span> <br />
               
            </div>
        </div>
    )









  
    return (
    
        <div className="row">
        <div className="col-md-12">
            <div className="jumbotron jumbotron-fluid py-4">
                <div className="container text-center">
                    <h1 className="display-4">List of Addvertisments</h1>
                </div>
            </div>
        </div>
        <div >
           
        </div>
        <div >
            <table>
                <tbody>
                    {
                        //tr > 3 td
                        [...Array(Math.ceil(employeeList.length / 3))].map((e, i) =>
                            <tr key={i}>
                                <td>{imageCard(employeeList[3 * i])}</td>
                                <td>{employeeList[3 * i + 1] ? imageCard(employeeList[3 * i + 1]) : null}</td>
                                <td>{employeeList[3 * i + 2] ? imageCard(employeeList[3 * i + 2]) : null}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        </div>
    </div>
                 
                
    


)
}


