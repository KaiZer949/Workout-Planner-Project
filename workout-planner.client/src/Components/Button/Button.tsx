const Button = (variant,name) => {
    return (
        <button className={`button button--${variant}` }>{name}</button>
  );
}

export default Button;