import dayjs from "dayjs";
import relativeTime from "dayjs/plugin/relativeTime";

function CommentsSection({comments, template}) {
  dayjs.extend(relativeTime);

  function formattedDate(date: string){
    let pastDate = dayjs(date)
    return pastDate.fromNow();
  }

  let commentsList = comments.map(comment => {
    return(<div>
      <div className="flex gap-2 mb-3">
        <img src={comment.profilePicture} className="h-12 rounded-full"/>
        <div className="block">
          <div className="flex gap-2 items-baseline">
            <p className="font-medium">{comment.username}</p>
            <p className="text-sm">{formattedDate(comment.dateCreated)}</p>
          </div>
          <p>{comment.content}</p>
        </div>
      </div>
      <div className="flex gap-2 ml-12">
        <img src={comment.childComments[0].profilePicture} className="h-12 rounded-full"/>
        <div className="block">
          <div className="flex gap-2 items-baseline">
            <p className="font-medium">{comment.childComments[0].username}</p>
            <p className="text-sm">{formattedDate(comment.childComments[0].dateCreated)}</p>
          </div>
          <p>{comment.childComments[0].content}</p>
      </div>
    </div>
    </div>)
  })
  return (
    <div className="p-4" style={{backgroundColor: template.mainColor + '80', borderRadius: template.borderRadius}}>
      {commentsList}
    </div>
  )
}

export default CommentsSection