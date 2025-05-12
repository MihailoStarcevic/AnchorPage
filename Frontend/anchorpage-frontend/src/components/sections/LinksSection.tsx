function LinksSection({data, template}) {
  const buttons = data.buttons.map(button => 
    {
        let textColor = button.textColor
        let color = button.color
        return (
            <li key={button.id}>
        <a 
            href={button.link}
            className="block py-6 text-center mb-3"
            target="_blank"
            style={{color: textColor, backgroundColor: color, fontSize: template.fontSize, border: 'solid', borderColor: button.strokeColor, borderWidth: button.strokeWidth, borderRadius: template.borderRadius}}>
                {button.content}
        </a>
    </li>
        )
    })
  return (
    <>
        <ul>
            {buttons}
        </ul>
    </>
  )
}

export default LinksSection