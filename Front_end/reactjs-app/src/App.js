import React from 'react'
import "./app.css"
import Home from './pages/Home/Home'
import BlogPage from './pages/Blog/BlogPage'
import { createBrowserRouter,RouterProvider } from 'react-router-dom'
import AddDestination from './pages/AddDestination/AddDestination'
import ShareImageDestination from './pages/ShareImageDestination/ShareImageDestination'
import AddQuestion from './pages/AddQuestion/AddQuestion'
import NamePlan from './Components/Forms/NamePlan/NamePlan'
import ListPlan from './Components/Forms/ListPlan/ListPlan'
import Register from './Components/Forms/Register/Register'
import IntroDes from './pages/IntroDes/IntroDes'
import DulichOfDestination from './pages/DulichOfDestination/DulichOfDestination'
import BlogOfDestination from './pages/BlogOfDestination/BlogOfDestination'
import BlogDetail from './pages/BlogDetail/BlogDetail'
import ReviewForm from './Components/Forms/ReviewForm/ReviewForm'
import MarkDestination from './pages/MarkDestination/MarkDestination'
import MyTravelMap from './pages/MyTravelMap/MyTravelMap'
import MarkDesSelect from './Components/MarkDesSelect/MarkDesSelect'
import ProfileUser from './Components/ProfileUser/ProfileUser'

const router = createBrowserRouter([
  {
    path:"/",
    element:<Home/>
  },
  {
    path:"/blog/viet-bai/note",
    element:<BlogPage/>
  },
  {
    path:"/cong-tac-vien/viet-bai/note",
    element:<AddDestination/>
  },
  {
    path:"/photo-blog/dang-bai/note",
    element:<ShareImageDestination/>
  },
  {
    path:"/hoi-dap",
    element:<AddQuestion/>
  },
  {
    path:"/m",
    element:<NamePlan/>
  },
  {
    path:"/n",
    element:<Register/>
  },
  {
    path:"/gioi-thieu/:id",
    element:<IntroDes/>
  },
  {
    path:"/diem-den/:id/diem-du-lich/",
    element:<DulichOfDestination/>
  },
  {
    path:"/diem-den/:id/blog/",
    element:<BlogOfDestination/>
  },
  {
    path:"/blog/:id/",
    element:<BlogDetail/>
  },
  {
    path:"/diem-den/:id/review",
    element:<ReviewForm/>
  },
  {
    path:"/danh-dau-diem-den",
    element:<MyTravelMap/>
  },
  {
    path:"/ll",
    element:<MarkDestination/>
  },
  {
    path:"/kk",
    element:<ProfileUser/>
  }

])
const App = () => {
  return (
    <div>
      <RouterProvider router={router}/>
    </div>
  )
}

export default App