import Axios from 'axios'
import configService from './config'

const ResuelveService = Axios.create({
    baseURL: configService.apiUrl
})
export default ResuelveService