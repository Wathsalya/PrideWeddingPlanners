import React, { useState, useEffect } from 'react'

const defaultImageSrc = '/img/add2.gif'

const initialFieldValues = {
    employeeID: 0,
    employeeName: '',
    occupation:'Decoration',
    located_distric: '',
    located_province:'',
    min_package:'',
    mid_package:'',
    max_package:'',
    telephoneNumber:'',
	companyWebsite:'',
    imageName: '',
    imageSrc: defaultImageSrc,
    imageFile: null
}

export default function Decoration(props) {

    const { addOrEdit, recordForEdit } = props

    const [values, setValues] = useState(initialFieldValues)
    const [errors, setErrors] = useState({})


    useEffect(() => {
        if (recordForEdit != null)
            setValues(recordForEdit);
    }, [recordForEdit])

    const handleInputChange = e => {
        const { name, value } = e.target;
        setValues({
            ...values,
            [name]: value
        })
    }

    const showPreview = e => {
        if (e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0];
            const reader = new FileReader();
            reader.onload = x => {
                setValues({
                    ...values,
                    imageFile,
                    imageSrc: x.target.result
                })
            }
            reader.readAsDataURL(imageFile)
        }
        else {
            setValues({
                ...values,
                imageFile: null,
                imageSrc: defaultImageSrc
            })
        }
    }

    const validate = () => {
        let temp = {}
        temp.employeeName = values.employeeName == "" ? false : true;
        temp.occupation = values.occupation == "" ? false : true;
        temp.imageSrc = values.imageSrc == defaultImageSrc ? false : true;
        setErrors(temp)
        return Object.values(temp).every(x => x == true)
    }

    const resetForm = () => {
        setValues(initialFieldValues)
        document.getElementById('image-uploader').value = null;
        setErrors({})
    }

    const handleFormSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const formData = new FormData()
            formData.append('employeeID', values.employeeID)
            formData.append('employeeName', values.employeeName)
            formData.append('occupation', values.occupation)
            formData.append('located_distric', values.located_distric)
            formData.append('located_province', values.located_province)
            formData.append('min_package', values.min_package)
            formData.append('max_package', values.max_package)
            formData.append('telephoneNumber', values.telephoneNumber)
            formData.append('companyWebsite', values.companyWebsite)

            formData.append('imageFile', values.imageFile)
            addOrEdit(formData, resetForm)
        }
    }

    const applyErrorClass = field => ((field in errors && errors[field] == false) ? ' invalid-field' : '')

    return (
     
        <>
          <div className="container text-center">
                <p className="lead">An Addvertisment</p>
           
            <form autoComplete="off" noValidate onSubmit={handleFormSubmit}>
                <div className="card">
                    <img src={values.imageSrc} className="card-img-top" />
                    <div className="card-body">
                        <div className="form-group">
                            <input type="file" accept="image/*" className={"form-control-file" + applyErrorClass('imageSrc')}
                                onChange={showPreview} id="image-uploader" />
                        </div>
                        <div className="form-group">
                            <input className={"form-control" + applyErrorClass('employeeName')} placeholder="Company Name" name="employeeName"
                                value={values.employeeName}
                                onChange={handleInputChange} />
                        </div>
                        <div className="form-group">
                            <input className={"form-control" + applyErrorClass('occupation')} placeholder="Company Category" name="occupation"
                                value={values.occupation}
                                onChange={handleInputChange} />
                        </div>

                        
                        <div className="form-group">
                            <input className="form-control" placeholder="Located Distric" name="located_distric"
                                value={values.located_distric}
                                onChange={handleInputChange} />
                        </div>
                        <div className="form-group">
                            <input className="form-control" placeholder="Located Province" name="located_province"
                                value={values.located_province}
                                onChange={handleInputChange} />
                        </div>

                        <div className="form-group">
                            <input className="form-control" placeholder=" Min Package" name="min_package"
                                value={values.min_package}
                                onChange={handleInputChange} />
                        </div>

         
                        <div className="form-group">
                            <input className="form-control" placeholder=" Max Package" name="max_package"
                                value={values.max_package}
                                onChange={handleInputChange} />
                        </div>

                        <div className="form-group">
                            <input className="form-control" placeholder=" TelephoneNumber" name="telephoneNumber"
                                value={values.telephoneNumber}
                                onChange={handleInputChange} />
                        </div>
						
						 <div className="form-group">
                            <input className="form-control" placeholder="Web-URL" name="companyWebsite"
                                value={values.companyWebsite}
                                onChange={handleInputChange} />
                        </div>


                        <div className="form-group text-center">
                            <button type="submit" className="btn btn-light">Submit</button>
                        </div>
                    </div>
                </div>
            </form>
            </div>
        </>
       
    )
}
