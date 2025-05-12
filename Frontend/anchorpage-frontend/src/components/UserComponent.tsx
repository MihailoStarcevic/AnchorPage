import React, { useEffect, useState } from 'react'
import api from '../api/axiosClient'
import { Link, Links, useParams } from 'react-router-dom';
import NotFound from './NotFound';
import LinksSection from './sections/LinksSection';
import NavbarComponent from './NavbarComponent';
import CommentsSection from './sections/CommentsSection';

const UserComponent = () => {

    //UseStates
    const username = useParams();
    const [status, setStatus] = useState<number>();
    const [user, setUser] = useState();
    const [activeSection, setActiveSection] = useState();
    const [shareVisible, setShareVisible] = useState(false);

    useEffect(() => {
      if(username && !user)
        {
          api.get("/user/" + username.username)
            .then(res => {
              setUser(res.data);
            })
            .catch(e => {
              if (e.response?.status === 404) {
                setStatus(404);
              }
            });
        }
      }, [username]);

      useEffect(() => {
        if (user && user.template?.sections?.length > 0 && !activeSection) {
          setActiveSection(user.template.sections[0]);
      }
  }, [user, activeSection]);
    if(status === 404)
      return <NotFound />;

    //If a user has been fetched
    if(user)
      {
        let sectionCount = Array.from(user.template.sections).length;

        let sectionComponents = {
          Links: LinksSection,
          Comments: CommentsSection
        };

        if(activeSection)
          var ActiveComponent = sectionComponents[activeSection.sectionType];

        const getWidthClass = (count: number) => {
          switch (count) {
            case 2: return '48%';
            case 3: return '32%';
            case 4: return 'w-1/4';
            case 5: return 'w-1/5';
            default: return 'w-auto'; // fallback
          }
        };

        //Sections
        if(user.template.sections)
        {
          var sections = user.template.sections.map(section => {
            const isActive = activeSection && section.id === activeSection.id;
            return(<span key={section.id} className={`flex items-center shadow-2xl justify-center text-center cursor-pointer text-xl rounded-2xl`} 
                style={{backgroundColor: user.template.accentColor, 
                  filter: isActive && 'brightness(4)', 
                  fontWeight: user.template.fontWeight,
                  width: getWidthClass(sectionCount),
                  boxShadow: '0 0px 8px rgba(0, 0, 0, 0.8)'}} 
                onClick={() => setActiveSection(section)}><p 
                key={section.id}>
                  {section.sectionType}
            </p></span>)
          }) 
        }
        
        //Share div
        let shareDiv = 
        <div className='w-1/4 z-50 bg-white rounded-2xl absolute px-6 py-4'>
          <div className='flex pb-4'>
            <p className='flex-1 text-center font-400 font-medium'>Share this AnchorPage</p>
            <p className='absolute cursor-pointer right-2 mr-4' onClick={() => setShareVisible(!shareVisible)}>
              <i className="fa-solid fa-xmark fa-sm"></i>
            </p>
          </div>
          <div className='relative h-60 flex justify-center items-center bg-cover bg-center rounded-3xl z-60' 
            style={{backgroundImage: `url("${user.template.backgroundImage}")`,
              boxShadow: 'inset 0 0 15px rgba(0, 0, 0, 1.8)'}}>
            <div
              className="absolute h-full w-full rounded-3xl z-70"
              style={{
                boxShadow: 'inset 0 0 20px rgba(0, 0, 0, 0.7)',  // Inner shadow only
                zIndex: 0,  // Ensure the shadow stays behind the content
              }}></div>
              <div className="absolute h-full w-full rounded-3xl bg-black/50 z-10" />
            <div className='relative block z-80'>
              <div className='flex justify-center'>
                <img src={user.profilePicture} className='h-18 rounded-full mb-2 select-none' draggable={false} />
              </div>
              <div className='block text-center text-white'>
                <div className='flex items-center text-center text-white mb-[-5px]'>
                  <img src='../../white-logo.png' className='h-5 mt-1 select-none' draggable={false}/>
                  <p className='text-[22px]'>/{user.username}</p>
                </div>
                <p className='font-light'>{user.template.description}</p>
              </div>
            </div>
          </div>
          <div className='flex justify-between gap-2 my-4 overflow-auto'>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer flex justify-center items-center' 
              style={{backgroundColor: user.template.mainColor}}
              onClick={() => navigator.clipboard.writeText('https://anchorpa.ge/' + user.username)}>
                <img src='../../white-logo.png' className='h-5'/>
              </span>
              <p className='text-center text-xs'>Copy</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer bg-black flex justify-center items-center'>
                <i className="fa-brands fa-x-twitter text-white fa-lg"></i>
              </span>
              <p className='w-full text-center text-xs break-words'>Twitter</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer bg-sky-600 flex justify-center items-center'>
                <i className="fa-brands fa-facebook-f text-white fa-lg"></i>
              </span>
              <p className='w-full text-center text-xs break-words'>Facebook</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer bg-green-400 flex justify-center items-center'>
                <i className="fa-brands fa-whatsapp text-white fa-xl"></i>
              </span>
              <p className='w-full text-center text-xs break-words'>Whatsapp</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer bg-cyan-600 flex justify-center items-center'>
                <i className="fa-brands fa-linkedin-in text-white fa-lg"></i>
              </span>
              <p className='w-full text-center text-xs break-words'>LinkedIn</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer bg-yellow-300 flex justify-center items-center'>
                <i className="fa-brands fa-snapchat text-black fa-lg"></i>
              </span>
              <p className='w-full text-center text-xs break-words'>Snapchat</p>
            </div>
            <div className='flex-1 flex flex-col items-center'>
              <span className='w-full aspect-square rounded-full cursor-pointer flex justify-center items-center' 
                style={{backgroundColor: user.template.accentColor}}>
                  <i class="fa-solid fa-angle-up text-white fa-l"></i>
                </span>
              <p className='w-full text-center text-xs break-words'>More...</p>
            </div>
          </div>
          <hr/>
          <div className='block my-5'>
            <p className='font-medium'>Make you own AnchorPage</p>
            <p className='text-sm font-light mb-4'>Join {user.username} and share all your links with the world.</p>
            <div className='flex justify-between gap-4'>
              <Link to="/" className='flex-1'>
                <span className='flex-1 flex rounded-2xl justify-center text-white px-5 py-2' 
                style={{backgroundColor: user.template.accentColor}}>Join for free</span>
              </Link>
              <Link to="/" className='flex-1'>
                <span className='flex-1 flex rounded-2xl justify-center px-4 py-2' style={{border: 'solid', borderWidth: 1, borderColor: user.template.mainColor}}>Learn more</span>
              </Link>
            </div>
          </div>
          <hr style={{backgroundColor: 'gray'}} />
          <div className='flex flex-1 mt-4'>
            <Link to="/" className='text-sm font-normal pl-4'><i className="fa-solid fa-flag"></i> Report this AnchorPage</Link>
          </div>
        </div>

        return(
          <div className='relative w-screen h-screen'>
            <div className='absolute w-screen h-screen bg-cover bg-center bg-fixed z-0' 
            style={{backgroundImage: `url("${user.template.backgroundImage}")`}}>
            </div>
            <div className="absolute inset-0 bg-black/70 z-10" />
            <div className='relative flex flex-col justify-center items-center w-screen h-screen z-20'>
              {shareVisible && shareDiv}
              <div className='w-1/3 h-1/3 flex justify-center items-end'>
                <div className='absolute right-0 top-0 p-5 text-white rounded-full w-12 h-12 m-5 flex items-center justify-center cursor-pointer' 
                  style={{backgroundColor: user.template.accentColor}}
                  onClick={() => setShareVisible(!shareVisible)}>
                    <span className="relative top-[-3px] font-mono select-none">...</span>
                </div>
                <Link to='/'>
                  <div className='absolute left-0 top-0 text-white rounded-full w-12 h-12 m-5 flex items-center justify-center cursor-pointer' 
                    style={{backgroundColor: user.template.accentColor}}>
                      <img src='../../white-logo.png' className='h-5'></img>
                  </div>
                </Link>
                <div className='block' style={{visibility: shareVisible ? 'hidden' : 'visible'}}>
                  <div className='flex justify-center mb-6'>
                    <img src={user.profilePicture} className='h-28 mr-3 rounded-full' style={{boxShadow: '0 0px 8px rgba(0, 0, 0, 0.8)'}}></img>
                    <div className='flex flex-col ml-3 justify-center text-white'>
                      <h2 className='text-4xl'>{user.displayName}</h2>
                      <p className='text-xl' style={{fontWeight: 200}}>{user.template.description}</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className='w-1/3 h-2/3' style={{visibility: shareVisible ? 'hidden' : 'visible'}}>
                <div className='block px-6'>
                  <div className='flex justify-between text-white text-center mb-4 h-12' 
                    style={{visibility: (sectionCount === 1 || shareVisible) ? 'hidden' : 'visible'}}>
                    {sectionCount === 0 ? <p>No sections found!</p> : sections}
                  </div>
                   {ActiveComponent && <ActiveComponent data={activeSection} template={user.template} comments={activeSection.comments} />}
                </div>
              </div>
            </div>
          </div>
        );
      }
}

export default UserComponent