import React,{Component} from 'react';
import {variables} from './Variables.js';
import edit_icon from './edit-icon.svg';
import delete_icon from './delete-icon.svg';
import add_icon from './add-icon.svg'

export class Regions extends Component
{
    constructor(props)
    {
        super(props);//call constructor of a parent class

        this.state={
            regions:[],
            modalTitle:"",
            RegionName:"",
            RegionId:0
        }
    }

    refreshList(){
        fetch(variables.API_URL + 'regions')
        .then(response=>response.json())
        .then(data=>{this.setState({regions:data});})
        .catch(error=>console.error('Unable to get regions',error));

    }

    componentDidMount()
    {
        this.refreshList();
    }

    changeRegionName = (e)=>{
        this.setState({RegionName:e.target.value});
    }

    createClick(){
        fetch(variables.API_URL+'regions',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Name:this.state.RegionName
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    updateClick(){
        fetch(variables.API_URL+'regions/'+this.state.RegionId,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                Id:this.state.RegionId,
                Name:this.state.RegionName
            })
        })
        .then(()=>{
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(id){
        fetch(variables.API_URL+'regions/'+id,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then(()=>{
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    addClick(){
        this.setState({
            modalTitle:"Add Region",
            RegionName:"",
            RegionId:0
        })
    }
    
    editClick(region){
        this.setState({
            modalTitle:"Edit Region",
            RegionName:region.name,
            RegionId:region.id
        })
    }

    render()
    {
        const{
            regions,
            modalTitle,
            RegionName,
            RegionId
        }=this.state;

        return(
            <div>
                <div  className='d-flex justify-content-end m-2'>
                    <button className='btn btn-secondary'
                    type="button"
                    data-bs-toggle='modal'
                    data-bs-target='#exampleModal'
                    onClick={()=> this.addClick()}>
                        <img className='mr-2' src={add_icon}/>
                        Add Region
                    </button>
                </div>

                <ul className='list-group'>
                    {regions.map(region =>
                        <li className='list-group-item' key={region.id}>
                            {region.name}
                            <button className='btn btn-light float-end'
                            onClick={()=>this.deleteClick(region.id)}>
                                <img src={delete_icon}/>
                            </button>
                            <button className='btn btn-light me-2 float-end'
                            data-bs-toggle='modal'
                            data-bs-target='#exampleModal'
                            onClick={()=> this.editClick(region)}>
                                <img src={edit_icon}/>
                            </button>
                            
                        </li>)}
                </ul>

                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className='modal-dialog modal-lg modal-dialog-centered'>
                        <div className='modal-content'>
                            <div className='modal-header'>
                                <h5 className='modal-title'>{modalTitle}</h5>
                                <button className='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>
                            </div>

                            <div className='modal-body'>
                                <div className='input-group mb-3'>
                                    <span className='input-group-text'>Region Name</span>
                                    <input type='text' className='form-control'
                                    value={RegionName}
                                    onChange={this.changeRegionName}/>
                                </div>

                                {RegionId==0?
                                <button className='btn btn-secondary float-start'
                                onClick={()=>this.createClick()}>
                                    Create
                                </button>:null}

                                {RegionId!=0?
                                <button className='btn btn-secondary float-start'
                                onClick={()=>this.updateClick()}>
                                    Update
                                </button>:null}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}