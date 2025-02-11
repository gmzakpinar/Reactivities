import { StrictMode } from 'react'
import App from './app/layout/App.tsx'
import 'semantic-ui-css/semantic.min.css'
import './app/layout/styles.css'
import ReactDOM from 'react-dom/client'


ReactDOM.createRoot(document.getElementById('root')!).render(
  <StrictMode>
  <App />
</StrictMode>,
)