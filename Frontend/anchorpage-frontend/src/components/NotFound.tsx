import { Link } from "react-router-dom"

function NotFound() {
  return (
    <div className="relative">
        <div className="absolute bg-[url(../../public/not-found.png)] bg-cover bg-center w-screen h-screen z-0"></div>
        <div className="absolute inset-0 bg-black/50 z-10" />
        <div className="relative flex justify-center items-center w-screen h-screen text-white z-20">
            <div className="text-center">
                <h1 className="text-[12em] leading-none font-medium">404</h1>
                <p className="text-2xl mb-5">The anchor you are looking for has sunk a long time ago.</p>
                <Link to="/"><span className="text-white bg-gray-800 hover:bg-gray-900 focus:outline-none focus:ring-4 focus:ring-gray-300 font-normal rounded-lg text-lg px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:hover:bg-gray-700 dark:focus:ring-gray-700 dark:border-gray-700">Back to the harbor</span></Link>
            </div>
        </div>
    </div>
  )
}

export default NotFound